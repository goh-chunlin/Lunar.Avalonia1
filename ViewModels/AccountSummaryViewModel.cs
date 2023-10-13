using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Lunar.Avalonia1.Models;
using Syncfusion.XlsIO;
using System.IO;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System.Threading.Tasks;
using MsBox.Avalonia.Base;
using Lunar.Avalonia1.Utils;
using System.Collections.Generic;

namespace Lunar.Avalonia1.ViewModels;

public class AccountSummaryViewModel: ObservableObject
{
    private ObservableCollection<Expense>? _expenseSummary;

    public ObservableCollection<Expense> ExpenseSummary 
    { 
        get => _expenseSummary ?? new ObservableCollection<Expense>(); 
        set => SetProperty(ref _expenseSummary, value); 
    }

    public DateTimeOffset SearchStartDate { get; set; } = DateTimeOffset.Now.AddMonths(-1);

    public DateTimeOffset SearchEndDate { get; set; } = DateTimeOffset.Now;

    public AccountSummaryViewModel()
    {        
        Task.Run(async () =>
        {
            await SearchReportAsync();
        });
    }

    public async Task OnSearchCommandAsync()
    {
        await SearchReportAsync();
    }

    public async Task OnExportToExcelCommandAsync()
    {
        await ExportReportToExcelAsync();
    }

    private async Task SearchReportAsync()
    {
        ExpenseSummary = new ObservableCollection<Expense>(
            Expense.Expenses
            .Where(e => e.TransactedAt >= SearchStartDate && e.TransactedAt <= SearchEndDate)
            .OrderByDescending(e => e.TransactedAt));

        // Send telemetry
        await Telemetry.SendTelemetryAsync("report", new Dictionary<string, string>
            {
                { "report", "account_summary" },
                { "action", "search" },
                { "action_date", DateTimeOffset.Now.ToString("yyyy-MM-dd") },
                { "start_date", SearchStartDate.ToString("yyyy-MM-dd") },
                { "end_date", SearchEndDate.ToString("yyyy-MM-dd") }
            }, ExpenseSummary.Count);
    }

    private async Task ExportReportToExcelAsync()
    {
        string fileName = $"ExpenseSummary_{DateTime.Now:yyyy-MM-dd-HHmmss}.xlsx";

        using (var excelEngine = new ExcelEngine())
        {
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Xlsx;

            // Create a new workbook
            IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

            // Access first worksheet from the workbook
            IWorksheet worksheet = workbook.Worksheets[0];

            // Set the header row
            worksheet.Range["A1"].Text = "Item";
            worksheet.Range["B1"].Text = "Remark";
            worksheet.Range["C1"].Text = "Amount (SGD)";
            worksheet.Range["D1"].Text = "Transaction Date";

            // Add the data rows
            var row = 2;
            foreach (var expense in ExpenseSummary)
            {
                worksheet.Range[row, 1].Text = expense.Title;
                worksheet.Range[row, 2].Text = expense.Remark;
                worksheet.Range[row, 3].Text = expense.Amount.ToString("N2");
                worksheet.Range[row, 4].Text = expense.TransactedAt.ToString("yyyy-MM-dd");

                row++;
            }

            // Check if file directory exists
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            // Save the workbook            
            FileStream stream = new($"output/{fileName}", FileMode.Create, FileAccess.ReadWrite);
            workbook.SaveAs(stream);

            // Dispose stream
            stream.Dispose();
        }

        IMsBox<ButtonResult> messageBox = MessageBoxManager
            .GetMessageBoxStandard("Successful Export", $"The report has been exported to the Excel file {fileName}.",
                ButtonEnum.Ok, Icon.Info);

        await messageBox.ShowAsync();

        // Send telemetry
        await Telemetry.SendTelemetryAsync("report", new Dictionary<string, string>
            {
                { "report", "account_summary" },
                { "action", "export" },
                { "action_date", DateTimeOffset.Now.ToString("yyyy-MM-dd") },
                { "start_date", SearchStartDate.ToString("yyyy-MM-dd") },
                { "end_date", SearchEndDate.ToString("yyyy-MM-dd") }
            }, ExpenseSummary.Count);
    }
}