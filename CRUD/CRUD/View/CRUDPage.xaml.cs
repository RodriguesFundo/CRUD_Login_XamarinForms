using CRUD.Models;
using CRUD.view;
using SQLite;
using System;
using System.Collections.Generic;
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

        private void tbItemSearch_Clicked(object sender, EventArgs e)
        {
            searchBar.IsVisible = true;
        }

        private void tbItemRemove_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Removed", "", "OK");
        }

        private void tbItemAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreatePage());

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = e.NewTextValue.ToLower();
            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>().Where(x => x.Name.ToLower().Contains(_searchText)).ToList();

            conn.Close();
        }

        private void tbItemExit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            itemSelected= (User)e.SelectedItem;

            Navigation.PushModalAsync(new UpdateUserPage(itemSelected));
        }
    }
}