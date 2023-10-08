using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lunar.Avalonia1.Models
{
    public class Expense : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string? Remark { get; set; }
        public DateTime TransactedAt { get; set; }

        public Expense(string title, string category, string currency, decimal amount, string remark, DateTime transactedAt)
        {
            Title = title;
            Category = category;
            Currency = currency;
            Amount = amount;
            Remark = remark;
            TransactedAt = transactedAt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public static List<Expense> Expenses { get; set; } = ExpenseGenerator.GenerateExpenses(500);
    }

    public static class ExpenseGenerator
    {
        private static readonly string[] Categories = { "Food", "Transportation", "Entertainment", "Shopping", "Housing", "Communication", "Education", "Medical", "Insurance", "Investment", "Others" };
        private static readonly string Currency = "SGD";
        private static readonly DateTime StartDate = new DateTime(2023, 1, 1);
        private static readonly DateTime EndDate = new DateTime(2023, 10, 7);

        public static List<Expense> GenerateExpenses(int count)
        {
            var expenses = new List<Expense>();

            for (int i = 0; i < count; i++)
            {
                var title = Categories[i % Categories.Length];
                var category = Categories[i % Categories.Length];
                var amount = (decimal)(new Random().NextDouble() * 1000 + 1);
                var remark = $"Expense {i + 1}";
                var transactedAt = StartDate.AddDays(new Random().Next((EndDate - StartDate).Days));

                var expense = new Expense(title, category, Currency, amount, remark, transactedAt);
                expenses.Add(expense);
            }

            return expenses;
        }
    }
}