﻿using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Diagnostics;

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
                AmountText.Text = details[0];
                newExpense.Type = details[1];
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
   
            if (string.IsNullOrEmpty(newExpense.FileName))
            {
                newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.expense.txt");
            }
            newExpense.Amount = AmountText.Text;
            //newExpense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.expense.txt");
            var content = $"{newExpense.Amount}-{newExpense.Type}";
            Debug.WriteLine(content);
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
            if(newExpense != null) {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Content != null)
            {
                newExpense.Type = (string)radioButton.Content;
            }
            }


        }
    }
}