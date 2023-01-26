using CRUD.Models;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateUserPage : ContentPage
    {

        private string _inputName;
        private string _inputEmail;
        private string _inputUsername;
        private string _inputPassword;
        string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");
        public UpdateUserPage(object user)
        {
            InitializeComponent();
            var userSelected = user as User;
            txtName.Text= userSelected.Name;
            txtEmail.Text= userSelected.Email;
            txtUsername.Text= userSelected.Username;
            txtPassword.Text= userSelected.Password;

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputName= e.NewTextValue;
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

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var conn = new SQLiteConnection(DBpath);
            User user = new User() { 
                Name= _inputName,
                Email= _inputEmail,
                Username= _inputUsername,
                Password= _inputPassword
            };
            conn.Update(user);
            Navigation.PopModalAsync();
        }
    }
}