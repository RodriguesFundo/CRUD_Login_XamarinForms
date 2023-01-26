using CRUD.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        private string _inputName;
        private string _inputEmail;
        private string _inputUsername;
        private string _inputPassword;
        string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");

        public AddUserPage()
        {
            InitializeComponent();


        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputName = e.NewTextValue;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputEmail = e.NewTextValue;
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputUsername = e.NewTextValue;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputPassword = e.NewTextValue;
        }

        private void btnAddUser_Clicked(object sender, EventArgs e)
        {

            var conn = new SQLiteConnection(DBpath);
            conn.CreateTable<User>();

            if (_inputName != null && _inputPassword != null && _inputUsername != null)
            {
                User usuario = new User()   
                {
                    Email = _inputEmail,
                    Password = _inputPassword,
                    Username = _inputUsername,
                    Name = _inputName

                };
                conn.Insert(usuario);
                DisplayAlert("Done!", usuario.Name.ToString()+" add", "Ok");

            }
            else { 
            }
        }

        private async void btnShow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowUser());
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage());
        }
    }
}