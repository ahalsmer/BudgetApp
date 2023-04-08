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
            // declaring expenses which is the list of new files getting sorted through the NewExpense class
            var expenses = new List<NewExpense>();
            // returns an enumerable collection of file names in the specified format
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var file in files)
            {
                // for each file in the in the aforementioned list, read the amount, expense, date, and type
                var expense = new NewExpense()
                {   
                    // How can I read just the text of the specific detail in the file separately
                    Amount = File.ReadAllText(file),
                    // How can I read the date that the user inputs?
                    Date = File.GetCreationTime(file),
                    Details = File.GetCreationTime(file) + " " ,// radioButton.Content should also go here
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
