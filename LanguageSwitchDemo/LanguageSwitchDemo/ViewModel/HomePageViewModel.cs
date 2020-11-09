using LanguageSwitchDemo.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LanguageSwitchDemo.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand ButtonItemIndexModeCommand { get; set; }

        public ICommand ButtoniMarkupExtensionModeCommand { get; set; }


        public HomePageViewModel()
        {
            // TODO:

            ButtonItemIndexModeCommand = new Command(OnClickedItemIndexMode);
            ButtoniMarkupExtensionModeCommand = new Command(OnClickediMarkupExtensionMode);
        }

        private async void OnClickediMarkupExtensionMode(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new iMarkupExtensionModePage());
        }

        private async void OnClickedItemIndexMode(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ItemIndexModePage());
        }
    }
}
