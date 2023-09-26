﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTakingApp
{
    public partial class App : Application
    {
        private static database database;
        public static database Database
        {
            get
            {
                if(database == null)
                {
                    database = new database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "note.db3"));
                }
                return database;

            }
            

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
