using BudgetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var expenses = new List<Expense>();
            /*
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.json");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var expense = JsonConvert.DeserializeObject<Expense>(json);
                expenses.Add(expense);

            } */
            var expense = new Expense()
            {
                Id = "shfghsd",
                Type = "Food",
                GoalValue = 100,
                Amount = 200,
                Date = DateTime.Now,
                
            
            };
            var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Food_expense.json");
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                var expense1 = JsonConvert.DeserializeObject<Expense>(json);
                expense.Amount = expense1.Amount;

            }
            expenses.Add(expense);



            ExpenseView.ItemsSource = expenses;
            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");
            if (File.Exists(FileName))
            {
                goal.Text = "Update Your Goals";
            }
            

        }

        private void ExpenseView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new ExpensePage
            {
                BindingContext = (Expense)e.SelectedItem
            });
        }

        private void Add_Goals(object sender, EventArgs e)
        {

            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                Navigation.PushModalAsync(new GoalPage
                {
                    BindingContext = goals
                });

                goal.Text = "Update Your Goals";

            }
            else
            {

                Navigation.PushModalAsync(new GoalPage
                {
                    BindingContext = new Goal()
                });

                goal.Text = "Update Your Goals";

            }
        }

        
    }
}
