using BudgetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MenuItem = BudgetApp.Models.MenuItem;

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
            ExpenseView.ItemsSource = expenses;
            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                Goal goalObject = JsonConvert.DeserializeObject<Goal>(json);
                int total = 0;
                if (goalObject != null)
                {
                    total = goalObject.Food + goalObject.Housing + goalObject.Miscellaneous + goalObject.Transportation + goalObject.Clothing + goalObject.Entertainment;
                }
                goal.Text = "Total Budget set is "+total;
            }

            var menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { Type = "Hosing" });
            menuItems.Add(new MenuItem { Type = "Clothing" });
            menuItems.Add(new MenuItem { Type = "Transportation" });
            menuItems.Add(new MenuItem { Type = "Entertainment" });
            menuItems.Add(new MenuItem { Type = "Miscellaneous" });


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
                Goal goalObject = JsonConvert.DeserializeObject<Goal>(json);

                Navigation.PushModalAsync(new GoalPage
                {
                    BindingContext = goalObject
                });
                int total = 0;
                json = File.ReadAllText(FileName);
                goalObject = JsonConvert.DeserializeObject<Goal>(json);
                Debug.WriteLine(File.ReadAllText(FileName));
                if (goalObject != null)
                {
                    total = goalObject.Food + goalObject.Housing + goalObject.Miscellaneous + goalObject.Transportation + goalObject.Clothing + goalObject.Entertainment;
                }
                goal.Text = "Total Budget set is " + total;

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

        private void BackButton_Clicked(object sender, EventArgs e)
        {

        }

        private void HamburgerButton_Clicked(object sender, EventArgs e)
        {

        }

        private void MenuView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void expense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ExpensePage
            {
                BindingContext = new Expense()
            });

        }
    }
}
