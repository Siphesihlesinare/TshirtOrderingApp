﻿using System;
using System.IO;
using TShirtOderingApp.Views;
using TshirtOrderingApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOderingApp
{
    public partial class App : Application
    {
        private static TeesDatabase teesDatabase;

        public static TeesDatabase Database
        {
            get
            {
                if (teesDatabase == null)
                    teesDatabase = new TeesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"TShirt.db3" ));

                return teesDatabase;

            }
        }
        public int ResumeAtTShirtOrderingApp { get; internal set; }

        public App()
        {
            InitializeComponent();

            Resources.Add("lightPink ", Color.FromHex("FFB6C1"));
            Resources.Add("pink", Color.FromHex("FFC0CB"));

            var nav = new NavigationPage(new TeeListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["pink"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
