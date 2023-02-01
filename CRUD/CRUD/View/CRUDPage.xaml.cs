using CRUD.Models;
using CRUD.view;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDPage : ContentPage
    {

        private string _searchText;
        private readonly string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");
        LoginPage loginPage= new LoginPage();
        User itemSelected = new User();
        public CRUDPage()
        {
            InitializeComponent();
            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>();
        }

        //Evento disparado quando o toolbarItemSearch e clicado (Mostrar a barra de pesquisa)
        private void tbItemSearch_Clicked(object sender, EventArgs e)
        {
            searchBar.IsVisible = true;
            searchBar.Focus();
        }

        //Evento disparado quando o toolbarItemAdd e clicado (Abrir um formulario para cadastro de novo usuario)
        private void tbItemAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreatePage());

        }

        //Evento disparado quando a barra de pesquisa e usada, ela retorna os dados (da BD) que estao a ser introduzidos
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = e.NewTextValue.ToLower();
            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>().Where(x => x.Name.ToLower().Contains(_searchText)).ToList();

            conn.Close();
        }

        //Evento disparado quando o toolbarItemExit e clicado (Sair do sistema)
        private void tbItemExit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        //Evento disparado quando um item da listView e selecionado
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            itemSelected= e.SelectedItem as User;
            if (itemSelected != null) {
                string action = await DisplayActionSheet("", "Cancel", null, "Edit", "Delete");
                if (action.Equals("Edit"))
                {
                    await Navigation.PushModalAsync(new UpdateUserPage(itemSelected));
                }
                else if (action.Equals("Delete"))
                {
                    var conn = new SQLiteConnection(DBpath);
                    await DisplayAlert("Deleted", itemSelected.Name, "Ok");
                    conn.Table<User>().Delete(x => x.Username.Equals(itemSelected.Username));
                    conn.Close();


                }
            }

        }

        //When pull to refresh a list view
        private void listView_Refreshing(object sender, EventArgs e)
        {
            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>();
            listView.IsRefreshing = false;
        }
    }
}