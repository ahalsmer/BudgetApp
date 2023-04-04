using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Models
{
    internal class Expense
    {
      public string Id { get; set; }
      public string Type { get; set; }

      public string GoalValue { get; set; }

       public string Amount { get; set;}

       public DateTime Date { get; set; }
    }
}
