using BudgetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetApp
{
    public partial class HomePage : ContentPage
    {
        
        public HomePage()
        {
            InitializeComponent();
           
    }
        protected override void OnAppearing()
        {
            var expenses = new List<NewExpense>();

            // returns an enumerable collection of file names in the specified format
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var details = content.Split('-');

                // for each file in the in the aforementioned list, read the amount, expense, date, and type
                var expense = new NewExpense()
                {
                    Amount = details[0],
                    Date = File.GetCreationTime(file),
                    Type = details[1],
                    Details = $"{File.GetCreationTime(file)}  - {details[1]}",
                    FileName = file
                };
                // add each expense to a list of expenses
                expenses.Add(expense);
            }
            // place expense items in descending order by date
            ExpenseView.ItemsSource = expenses.OrderByDescending(t => t.Date);


            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");
            //File.Delete( FileName );

            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);
                var balanceList = new List<Balance>();
                int FoodBalance = goals.Food;
                int ShoppingBalance = goals.Shopping;
                int HousingBalance = goals.Housing;
                int TransportationBalance = goals.Transportation;
                int EntertainmentBalance = goals.Entertainment;
                int MiscellaneousBalance = goals.Miscellaneous;
                foreach (var item in expenses)
                {
                    if (item.Amount != "")
                    {
                        if (item.Type == "Food")
                        {
                            FoodBalance -= int.Parse(item.Amount);
                        }
                        if (item.Type == "Shopping")
                        {
                            ShoppingBalance -= int.Parse(item.Amount);
                        }
                        if (item.Type == "Housing")
                        {
                            HousingBalance -= int.Parse(item.Amount);
                        }
                        if (item.Type == "Transportation")
                        {
                            TransportationBalance -= int.Parse(item.Amount);
                        }
                        if (item.Type == "Entertainment")
                        {
                            EntertainmentBalance -= int.Parse(item.Amount);
                        }
                        if (item.Type == "Miscellaneous")
                        {
                            MiscellaneousBalance -= int.Parse(item.Amount);
                        }
                    }
                }
                var FoodBalanceInfo = new Balance
                {
                    Type = "Food",
                    value = FoodBalance
                };
                var ShoppingBalanceInfo = new Balance
                {
                    Type = "Shopping",
                    value = ShoppingBalance
                };
                var HousingBalanceInfo = new Balance
                {
                    Type = "Housing",
                    value = HousingBalance
                };
                var TransportationBalanceInfo = new Balance
                {
                    Type = "Transportation",
                    value = TransportationBalance
                };
                var EntertainmentBalanceInfo = new Balance
                {
                    Type = "Entertainment",
                    value = EntertainmentBalance
                };
                var MiscellaneousBalanceInfo = new Balance
                {
                    Type = "Miscellaneous",
                    value = MiscellaneousBalance
                };

                balanceList.Add(FoodBalanceInfo);
                balanceList.Add(ShoppingBalanceInfo);
                balanceList.Add(HousingBalanceInfo);
                balanceList.Add(TransportationBalanceInfo);
                balanceList.Add(EntertainmentBalanceInfo);
                balanceList.Add(MiscellaneousBalanceInfo);

                GoalListView.ItemsSource = balanceList;
                int total = 0;
                json = File.ReadAllText(FileName);
                Goal goalObject = JsonConvert.DeserializeObject<Goal>(json);
                Debug.WriteLine(File.ReadAllText(FileName));
                if (goalObject != null)
                {
                    total = goalObject.Food + goalObject.Housing + goalObject.Miscellaneous + goalObject.Transportation + goalObject.Shopping + goalObject.Entertainment;
                }
                goal.Text = "Total Budget set is " + total;
            }
        }

        private void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new NewExpensePage
            {
                BindingContext = (NewExpense)e.SelectedItem
            });
        }

        private void Expense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NewExpensePage
            {
                BindingContext = new NewExpense()
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
                    total = goalObject.Food + goalObject.Housing + goalObject.Miscellaneous + goalObject.Transportation + goalObject.Shopping + goalObject.Entertainment;
                }
                goal.Text = "Total Budget set is " + total;

            }
            else
            {

                Navigation.PushModalAsync(new GoalPage
                {
                    BindingContext = new Goal()
                });

                int total = 0;
                string json = File.ReadAllText(FileName);
                Goal goalObject = JsonConvert.DeserializeObject<Goal>(json);
                Debug.WriteLine(File.ReadAllText(FileName));
                if (goalObject != null)
                {
                    total = goalObject.Food + goalObject.Housing + goalObject.Miscellaneous + goalObject.Transportation + goalObject.Shopping + goalObject.Entertainment;
                }
                goal.Text = "Total Budget set is " + total;


            }
        }


    }
}
