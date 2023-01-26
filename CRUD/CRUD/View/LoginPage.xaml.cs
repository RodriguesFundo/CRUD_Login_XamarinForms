using CRUD.Models;
using Microsoft.Data.SqlClient;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");

        public LoginPage( )
        {
            InitializeComponent();
            var conn= new SQLiteConnection (DBpath);
            conn.CreateTable<User>();

        }
        private string _user;
        public string User { get; set; }
        private string _password;

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            
            if (_user != null && _password != null ) {
                if (_user.ToLower().Equals("user") && _password.Equals("1234")) {
                    await Navigation.PushAsync(new MainPage());
                }
                else {
                    await DisplayAlert("Error!", "Username or password are incorrect", "Ok");
                }
            }

            else
                await DisplayAlert("Blank spaces", "Blank spaces are not allowed", "Ok");
        }

       

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            _user = e.NewTextValue;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _password = e.NewTextValue;
        }

        public string getUser() {

            return _user;
        }

    }
}