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
    public partial class EditPage : ContentPage
    {
        private Entry _inputName;
        private Entry _inputEmail;

        ListView listView;
        User user = new User();
        string DBpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BD");

        public EditPage()
        {
//            InitializeComponent();
            var db = new SQLiteConnection(DBpath);
            StackLayout stackLayout = new StackLayout();
            listView = new ListView();
            listView.ItemsSource = db.Table<User>().OrderBy(x => x.Name).ToList();
            listView.ItemSelected += listView_ItemSelected;
            stackLayout.Children.Add(listView);
            
            _inputName = new Entry();
            _inputName.Placeholder = "Name";
            _inputName.IsVisible = true;
            stackLayout.Children.Add(_inputName);

            _inputEmail = new Entry();
            _inputEmail.Placeholder = "Email";
            _inputEmail.IsVisible = true;
            stackLayout.Children.Add(_inputEmail);

            Button btn = new Button();
            btn.Text= "Save";
            btn.IsVisible = true;
            stackLayout.Children.Add(btn);

            Content = stackLayout;


        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            user = (User)e.SelectedItem;
            _inputName.Text = user.Name.ToString();
            _inputEmail.Text = user.Email.ToString();

        }
    }
}