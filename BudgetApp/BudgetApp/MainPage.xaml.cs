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
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*expense.json");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var expense = JsonConvert.DeserializeObject<Expense>(json);
                expenses.Add(expense);

            }
            bool foodFlag = false;
            bool ClothingFlag = false;
            bool HousingFlag = false;
            bool TransportationFlag = false;
            bool EntertainmentFlag = false;
            bool MiscellaneousFlag = false;
           
            foreach (var item in expenses)
            {
                if(item.Type == "Food")
                {
                    foodFlag = true;
                }
                if (item.Type == "Clothing")
                {
                    ClothingFlag = true;
                }
                if (item.Type == "Housing")
                {
                    HousingFlag = true;
                }
                if (item.Type == "Transportation")
                {
                    TransportationFlag = true;
                }
                if (item.Type == "Entertainment")
                {
                    EntertainmentFlag = true;
                }
            }
            if (!foodFlag) {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Food",
                    GoalValue = goals.Food,
                    Amount = 0,
                    Date = DateTime.Now,
            };
                expenses.Add(expense);
            }
            if (!ClothingFlag)
            {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Clothing",
                    GoalValue = goals.Clothing,
                    Amount = 0,
                    Date = DateTime.Now,
                };
                expenses.Add(expense);
            }
            /*
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
                expense.GoalValue = expense1.GoalValue;

            }
            expenses.Add(expense); */



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
