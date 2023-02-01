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

            if (userCount().Equals(0))
            {
                btnCRUDOpen.IsVisible = false;
                lblIsFirstTime.Text = "E a primeira vez a usar esta aplicacao, adicione um usuario clicando no icone acima";
                lblTobtnCrud.Text = "Adicione pelo menos um usuario clicando no botao abaixo ";
            }
            else { 
                btnCRUDOpen.IsVisible = true;
                btnAddFirstUser.IsVisible = false;
            }


        }

        //Open  CRUD page
        private async void btnCRUDOpen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDPage());
        }

        //Count the users,number
        public int userCount() { 
            var db = new SQLiteConnection(DBpath);
            int userCount = db.Table<User>().Count();
            db.Close();
            return userCount;
        }

        //ADD a new user
        private void tbItemAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreatePage());
        }

        
        //Only if the first time to open a APP
        private void btnAddFirstUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreatePage());
        }
    }
}