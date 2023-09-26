using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace NoteTakingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNotePage : ContentPage
    {
        public NewNotePage()
        {
            InitializeComponent();
        }
        notes n;
        public NewNotePage(notes note)
        {
            InitializeComponent();
            n = note;
            titleEntry.Text = note.title;
            TextBox.Text = note.description;
            titleEntry.Focus();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TextToSpeech.SpeakAsync(TextBox.Text);

        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBox.Text) || string.IsNullOrWhiteSpace(titleEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or whiteSpace value is Invalid!", "OK");
            }
            else if(n!=null)
            {
                UpdateNote();

            }
            else
            {
                AddNewNote();
            }

        }
        async void AddNewNote()
        {
            await App.Database.CreateNotes(new notes
            {
                title = titleEntry.Text,
                description = TextBox.Text


            });
            await Navigation.PopAsync();
        }

        async void UpdateNote()
        {
            n.title = titleEntry.Text;
            n.description = TextBox.Text;   
            await App.Database.UpdateNotes(n);
            await Navigation.PopAsync();
        }

       
    }

   
}