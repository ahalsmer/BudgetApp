using BudgetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage : ContentPage
    {
        public ExpensePage()
        {
            InitializeComponent();
            Amount.Text= string.Empty;
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            //expense.Type = "Food";
            if (string.IsNullOrEmpty(expense.Type))
            {
                expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{expense.Type}_expense.json");
            }
            //expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{expense.Type}_expense.json");
            expense.Amount = int.Parse(Amount.Text);
            expense.Date = Date.Date;

            string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

            string json = File.ReadAllText(GoalFileName);
            Goal goals = JsonConvert.DeserializeObject<Goal>(json);

            //if expense.Type == "Food"
            expense.GoalValue = goals.Food;

            string expenseinfo = JsonConvert.SerializeObject(expense);

            Debug.WriteLine(expenseinfo);


            // Save the JSON to a file
            File.WriteAllText(expense.FileName, expenseinfo);
            Navigation.PopModalAsync();
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (File.Exists(expense.FileName))
            {
                File.Delete(expense.FileName);
            }
            Amount.Text = String.Empty;
            Navigation.PopModalAsync();
        }
    }
}