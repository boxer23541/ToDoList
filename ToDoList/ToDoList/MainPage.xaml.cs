using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList;
using Xamarin.Forms;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.BindingContext is Item item)
            {
                item.IsComplete = e.Value;
                await App.Database.SaveItemAsync(item);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetItemsAsync();
        }

        public async void OnButtonClicked(Object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SaveItemAsync(new Item
                {
                    Name = nameEntry.Text,
                    IsComplete = false  
                });
                nameEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetItemsAsync();
            }
        }

    }
}
