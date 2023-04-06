using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Models
{
    internal class Expense
    {
      public string Id { get; set; }
      public string Type { get; set; }

      public int GoalValue { get; set; }

       public int Amount { get; set;}

       public DateTime Date { get; set; }

        public string FileName { get; set; }

        public double AmountProgress
        {
            get { return Amount / GoalValue*10; }
        }

        public double GoalProgress
        {
            get { return 1.0; }
        }
    }
}
