using LanguageSwitchDemo.Model;
using LanguageSwitchDemo.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageSwitchDemo
{
    public partial class App : Application
    {

        public static AppConfig Config { get; set; } = new AppConfig();


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
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
