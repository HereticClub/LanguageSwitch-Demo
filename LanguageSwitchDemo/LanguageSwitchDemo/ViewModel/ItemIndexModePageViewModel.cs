using LanguageSwitchDemo.Model;
using LanguageSwitchDemo.View;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LanguageSwitchDemo.ViewModel
{
    public class ItemIndexModePageViewModel : BaseViewModel
    {



        public ICommand ButtonSelectLanguageCommand { get; set; }


        public TranslationHelper Languages { get; set; }


        public ItemIndexModePageViewModel()
        {
            // TODO:

            Languages = new TranslationHelper();

            ButtonSelectLanguageCommand = new Command(OnClickedSelectLanguage);
        }


        private void OnClickedSelectLanguage(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new SelectLanguage1Page());
        }
    }
}
