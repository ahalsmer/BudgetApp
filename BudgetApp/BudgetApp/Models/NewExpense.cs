using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Models
{
    internal class NewExpense
    {
        public string Expense { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
    }
}
