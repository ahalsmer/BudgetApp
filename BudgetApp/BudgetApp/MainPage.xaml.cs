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
                if (item.Type == "Miscellaneous")
                {
                    MiscellaneousFlag = true;
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
                    ImageUrl= "/Assets/Images/food-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Food_expense.json")
            };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
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
                    ImageUrl = "/Assets/Images/shopping-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Clothing_expense.json")
                };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
                expenses.Add(expense);
                expenses.Add(expense);
            }
            /*
            if (!HousingFlag)
            {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Housing",
                    GoalValue = goals.Clothing,
                    Amount = 0,
                    Date = DateTime.Now,
                    ImageUrl = "/Assets/Images/shopping-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Housing_expense.json")
                };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
                expenses.Add(expense);
                expenses.Add(expense);
            }
           
            if (!TransportationFlag)
            {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Transportation",
                    GoalValue = goals.Clothing,
                    Amount = 0,
                    Date = DateTime.Now,
                    ImageUrl = "/Assets/Images/shopping-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Transportation_expense.json")
                };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
                expenses.Add(expense);
                expenses.Add(expense);
            }
            if (!EntertainmentFlag)
            {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Entertainment",
                    GoalValue = goals.Clothing,
                    Amount = 0,
                    Date = DateTime.Now,
                    ImageUrl = "/Assets/Images/shopping-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Entertainment_expense.json")
                };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
                expenses.Add(expense);
                expenses.Add(expense);
            }

            if (!MiscellaneousFlag)
            {
                string GoalFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

                string json = File.ReadAllText(GoalFileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);

                //if expense.Type == "Food"
                var expense = new Expense()
                {
                    Id = "0",
                    Type = "Miscellaneous",
                    GoalValue = goals.Clothing,
                    Amount = 0,
                    Date = DateTime.Now,
                    ImageUrl = "/Assets/Images/shopping-icon.png",
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Miscellaneous_expense.json")
                };
                string expenseinfo = JsonConvert.SerializeObject(expense);
                File.WriteAllText(expense.FileName, expenseinfo);
                expenses.Add(expense);
                expenses.Add(expense);
            }
            */

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
