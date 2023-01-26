using CRUD.Models;
using CRUD.View;
using Microsoft.Data.SqlClient;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using Path = System.IO.Path;

namespace CRUD.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly string DBpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BD");

        public MainPage()
        {             
            InitializeComponent();
            lblCount.Text = "O nosso servico contem actualmente "+ userCount()+" usuarios;";

        }

        private async void btnCRUDOpen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDPage());
        }

        public int userCount() { 
            var db = new SQLiteConnection(DBpath);
            int userCount = db.Table<User>().Count();
            db.Close();
            return userCount;
        }

        

    }
}