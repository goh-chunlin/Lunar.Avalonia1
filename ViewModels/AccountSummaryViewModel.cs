using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Lunar.Avalonia1.Models;

namespace Lunar.Avalonia1.ViewModels;

public class AccountSummaryViewModel: ObservableObject
{
    private ObservableCollection<Expense> _expenseSummary;

    public ObservableCollection<Expense> ExpenseSummary 
    { 
        get => _expenseSummary; 
        set => SetProperty(ref _expenseSummary, value); 
    }

    public DateTimeOffset SearchStartDate { get; set; } = DateTimeOffset.Now.AddMonths(-1);

    public DateTimeOffset SearchEndDate { get; set; } = DateTimeOffset.Now;

    public AccountSummaryViewModel()
    {
        ExpenseSummary = new ObservableCollection<Expense>(Expense.Expenses);
    }

    public void OnSearchCommand()
    {
        ExpenseSummary = new ObservableCollection<Expense>(
            Expense.Expenses.Where(e => e.TransactedAt >= SearchStartDate && e.TransactedAt <= SearchEndDate));
    }
}