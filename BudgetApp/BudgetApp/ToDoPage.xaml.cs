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
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var todo = (NewExpense)BindingContext;
            if (todo != null && !string.IsNullOrEmpty(todo.FileName))
            {
                ToDoText.Text = File.ReadAllText(todo.FileName);
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var newExpense = (NewExpense)BindingContext;
            newExpense.Text = ToDoText.Text;
            if (string.IsNullOrEmpty(newExpense.FileName))
            {
                todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            }
            todo.Text = ToDoText.Text;
            todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");

            File.WriteAllText(todo.FileName, todo.Text);
            Navigation.PopModalAsync();
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var todo = (NewExpense)BindingContext;
            if (File.Exists(todo.FileName))
            {
                File.Delete(todo.FileName);
            }
            ToDoText.Text = String.Empty;
            Navigation.PopModalAsync();
        }
    }
}