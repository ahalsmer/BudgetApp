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
            var todos = new List<ToDo>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var file in files)
            {
                var todo = new ToDo()
                {
                    Text = File.ReadAllText(file),
                    Date = File.GetCreationTime(file),
                    FileName = file
                };
                todos.Add(todo);
            }
            ToDoListView.ItemsSource = todos.OrderByDescending(t => t.Date);
        }

        private void ToDoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new ToDoPage
            {
                BindingContext = (ToDo)e.SelectedItem
            });
        }

        private void NewToDo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ToDoPage
            {
                BindingContext = new ToDo()
            });
        }
    }
}
