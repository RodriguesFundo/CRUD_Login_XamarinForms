using CRUD.Models;
using Microsoft.Data.SqlClient;
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
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        //private Entry inputUser;
        //private Entry inputName;
        //private Entry inputEmail;
        //private Entry inputPassword;
        //private Entry inputPassword2;

        private string _inputUser;
        private string _inputName;
        private string _inputEmail;
        private string _inputPassword;
        private string _inputPassword2;
        private readonly string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            if (_inputUser != null && _inputName != null && _inputEmail != null && _inputPassword != null && _inputPassword2 != null)
            {
                if (_inputPassword.Equals(_inputPassword2))
                {
                    var conn= new SQLiteConnection(DBpath);
                    User usuario = new User()
                    {
                        Email = _inputEmail,
                        Password = _inputPassword,
                        Username = _inputUser,
                        Name = _inputName

                    };
                    conn.Insert(usuario);

                    await DisplayAlert("Done!", "Account create! "+_inputName.ToString(), "Ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Different passwords", "Your passwords must be the same", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Blank spaces", "Blank spaces are not allowed", "Ok");
                
            }
            //inputUser.Text="";
            //inputName.Text = "";
            //inputEmail.Text = "";
            //inputPassword.Text = "";
            //inputPassword2.Text = "";



        }
            
        

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputUser = e.NewTextValue;
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputName = e.NewTextValue;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputEmail=e.NewTextValue;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputPassword=e.NewTextValue;
        }

        private void txtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _inputPassword2=e.NewTextValue;
        }
    }
}