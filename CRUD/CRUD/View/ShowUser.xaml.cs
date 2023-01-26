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
    public partial class ShowUser : ContentPage
    {
        private string _searchText;
        string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");
        public ShowUser()
        {

            InitializeComponent();

            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>().Select(x => x.Name).ToList();

        }

        private async void tbItemSearch_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreatePage());
        }

        private void tbItemRemove_Clicked(object sender, EventArgs e)
        {
            searchBar.IsVisible = true;
        }

        private void tbItemAdd_Clicked(object sender, EventArgs e)
        {

        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = e.NewTextValue.ToLower();
            var conn = new SQLiteConnection(DBpath);
            listView.ItemsSource = conn.Table<User>().Where(x => x.Name.ToLower().Contains(_searchText)).ToList();

            conn.Close();
        }

    }
}