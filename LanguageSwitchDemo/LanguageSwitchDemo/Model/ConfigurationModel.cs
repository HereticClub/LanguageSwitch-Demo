using LanguageSwitchDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSwitchDemo.Model
{
    public class AppConfig : BaseViewModel
    {
        private string _selectedLanguage;


        public string SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                OnPropertyChanged(ref _selectedLanguage, value, "SelectedLanguage");
            }
        }
        

        public AppConfig()
        {
            // TODO:
        }
    }
}
