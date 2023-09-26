using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace NoteTakingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNotePage());

        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                TheCollectionView.ItemsSource = await App.Database.ReadNotes();
            }
            catch { }
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as notes;
            await Navigation.PushAsync(new NewNotePage(emp));

        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as notes;
            var result = await DisplayAlert("Delete", $"Delete {emp.title} from My Notes?", "Yes", "No");
            if(result)
            {
                await App.Database.DeleteNotes(emp);
                TheCollectionView.ItemsSource = await App.Database.ReadNotes();
            }
            


        }
    }
}
