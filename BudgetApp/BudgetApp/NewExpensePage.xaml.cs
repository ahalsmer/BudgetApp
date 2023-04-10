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
            var newExpense = (NewExpense)BindingContext;
            if (newExpense != null && !string.IsNullOrEmpty(newExpense.FileName))
            {
                var content = File.ReadAllText(newExpense.FileName);
                var details = content.Split('-');
                AmountText.Text = details[1];
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
            newExpense.Amount = AmountText.Text;
   
            if (string.IsNullOrEmpty(newExpense.FileName))
            {
                newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            }
            newExpense.Amount = AmountText.Text;
            newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            var content = $"{newExpense.Amount}/n{newExpense.Date} - {newExpense.Type}";
            File.WriteAllText(newExpense.FileName, content);
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

        private void category_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
            RadioButton radioButton = sender as RadioButton;
            newExpense.Type = (string)radioButton.Content;
     

        }
    }
}