using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                AmountText.Text = File.ReadAllText(newExpense.FileName);
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            // how can I change this to reflect the different categories of a new expense?
            var newExpense = (NewExpense)BindingContext;
            newExpense.Amount = AmountText.Text;
            if (string.IsNullOrEmpty(newExpense.FileName))
            {
                newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            }
            newExpense.Amount = AmountText.Text;
            newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");

            File.WriteAllText(newExpense.FileName, newExpense.Amount);
            Navigation.PopModalAsync();
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
            if (File.Exists(newExpense.FileName))
            {
                File.Delete(newExpense.FileName);
            }
            AmountText.Text = String.Empty;
            Navigation.PopModalAsync();
        }

        private void housingButton_Clicked(object sender, EventArgs e)
        {

        }

        private void transportationButton_Clicked(object sender, EventArgs e)
        {

        }

        private void foodButton_Clicked(object sender, EventArgs e)
        {

        }

        private void clothingButton_Clicked(object sender, EventArgs e)
        {

        }

        private void entertainmentButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}