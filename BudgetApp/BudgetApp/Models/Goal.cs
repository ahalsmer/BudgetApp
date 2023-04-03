using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Models
{
    internal class Goal
    {
        public String Food { get; set; }
        public String Clothing { get; set; }
        public String Housing { get; set; }
        public String Transportation { get; set; }
        public String Entertainment { get; set; }
        public String Miscellaneous { get; set; }
        public DateTime Date { get; set; }
        public String FileName { get; set; }
    }
}

