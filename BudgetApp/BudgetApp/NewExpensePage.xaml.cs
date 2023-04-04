using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace BudgetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        public NewExpensePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            // what exactly is happening here?
            var newExpense = (NewExpense)BindingContext;
            if (newExpense != null && !string.IsNullOrEmpty(newExpense.FileName))
            {
                NewExpenseText.Text = File.ReadAllText(newExpense.FileName);
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            // how can I change this to reflect the different categories of a new expense?
            var newExpense = (NewExpense)BindingContext;
            newExpense.Text = NewExpenseText.Text;
            if (string.IsNullOrEmpty(newExpense.FileName))
            {
                newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            }
            newExpense.Text = NewExpenseText.Text;
            newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");

            File.WriteAllText(newExpense.FileName, newExpense.Text);
            Navigation.PopModalAsync();
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
            if (File.Exists(newExpense.FileName))
            {
                File.Delete(newExpense.FileName);
            }
            NewExpenseText.Text = String.Empty;
            Navigation.PopModalAsync();
        }
    }
}