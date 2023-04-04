using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Models
{
    internal class Goal
    {
        public int Food { get; set; }
        public int Clothing { get; set; }
        public int Housing { get; set; }
        public int Transportation { get; set; }
        public int Entertainment { get; set; }
        public int Miscellaneous { get; set; }
        public DateTime Date { get; set; }
        public String FileName { get; set; }
    }
}

