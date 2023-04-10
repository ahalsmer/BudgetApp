using BudgetApp.Models;
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
            var expenses = new List<NewExpense>();
    
            // returns an enumerable collection of file names in the specified format
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var details = content.Split('-');

                // for each file in the in the aforementioned list, read the amount, expense, date, and type
                var expense = new NewExpense()
                {
                    Amount = details[0],
                    Date = File.GetCreationTime(file),
                    Type = details[0],
                    Details = $"{File.GetCreationTime(file)}  - {details.Length}",
                    FileName = file
                };
                // add each expense to a list of expenses
                expenses.Add(expense);
            }
            // place expense items in descending order by date
            NewExpenseListView.ItemsSource = expenses.OrderByDescending(t => t.Date);
        }

        private void NewExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new NewExpensePage
            {
                BindingContext = (NewExpense)e.SelectedItem
            });
        }

        private void NewExpense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NewExpensePage
            {
                BindingContext = new NewExpense()
            });
        }
    }
}
