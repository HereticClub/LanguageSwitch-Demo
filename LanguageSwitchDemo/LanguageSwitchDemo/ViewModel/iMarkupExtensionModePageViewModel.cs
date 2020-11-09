using LanguageSwitchDemo.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LanguageSwitchDemo.ViewModel
{
    public class iMarkupExtensionModePageViewModel : BaseViewModel
    {

        public ICommand ButtonSelectLanguageCommand { get; set; }


        public iMarkupExtensionModePageViewModel()
        {
            // TODO:

            ButtonSelectLanguageCommand = new Command(OnClickedSelectLanguage);
        }


        private void OnClickedSelectLanguage(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new SelectLanguage2Page());
        }
    }
}
