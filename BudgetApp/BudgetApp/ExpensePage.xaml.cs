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
        public List<string> Categories { get; set; }

        //public string SelectedCategory { get; set; }
        public ExpensePage()
        {
            InitializeComponent();
            Amount.Text= string.Empty;
            Categories = new List<string>
        {
            "Food",
            "Transportation",
            "Entertainment",
            "Clothing",
            "Housing",
            "Miscellaneous" 
        };

            CategoryPicker.ItemsSource = Categories;
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            Debug.WriteLine("My Expense"+expense);
            //expense.Type = "Food";
            if (string.IsNullOrEmpty(expense.FileName))
            {
                expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}{expense.Type}_expense.json");
            }
            //expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"}{expense.Type}_expense.json");
            int amount = 0;
            if(Amount.Text != "") {
                amount = int.Parse(Amount.Text);
            }
            expense.Amount = amount;
            
            expense.Date = Date.Date;

            string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

            string json = File.ReadAllText(GoalFileName);
            Goal goals = JsonConvert.DeserializeObject<Goal>(json);

            Debug.WriteLine(expense.Type + "Selected cat");
            
            if(expense.Type == "Food")
            {
                expense.GoalValue = goals.Food;
            }
            if (expense.Type == "Transportation")
            {
                expense.GoalValue = goals.Transportation;
            }
            if (expense.Type == "Entertainment")
            {
                expense.GoalValue = goals.Entertainment;
            }
            if (expense.Type == "Clothing")
            {
                expense.GoalValue = goals.Clothing;
            }
            if (expense.Type == "Housing")
            {
                expense.GoalValue = goals.Housing;
            }
            if (expense.Type == "Miscellaneous")
            {
                expense.GoalValue = goals.Miscellaneous;
            }


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