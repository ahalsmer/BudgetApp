using BudgetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalPage : ContentPage
    {
        public GoalPage()
        {
            InitializeComponent();
            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                Goal goals = JsonConvert.DeserializeObject<Goal>(json);
            }

            }

            private void Button_Clicked(object sender, EventArgs e)
        {
            var goal = (Goal)BindingContext;

            string food = "" ;
            string clothing = "";
            string housing = "" ;
            string transportation = "";
            string entertainment= "";
            string miscellaneous = "" ;
            DateTime date = DateTime.Now;


                food = Food.Text;
                clothing = Clothing.Text;
                housing = Housing.Text;
                transportation = Transportation.Text;
                entertainment = Entertainment.Text;
                miscellaneous = Miscellaneous.Text;
                date = Date.Date;

            
           
            string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"goals.json");

         
            goal.Food = food;
            goal.Clothing = clothing;
            goal.Housing = housing;
            goal.Transportation = transportation;
            goal.Entertainment = entertainment;
            goal.Miscellaneous = miscellaneous;
            goal.FileName = FileName;
            goal.Date = date;

        

            string json = JsonConvert.SerializeObject(goal);
    



            // Save the JSON to a file
            File.WriteAllText(goal.FileName,json);
            Debug.WriteLine(goal.FileName);

            Debug.WriteLine(File.ReadAllText(FileName));

            Navigation.PopModalAsync();

        }
    }
}