using LanguageSwitchDemo.Resource;
using LanguageSwitchDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LanguageSwitchDemo.Model
{

    public class TranslationHelper : BaseViewModel
    {
        private CultureInfo ci;
        private ResourceManager rm;
        private string _selectedLangId;


        public string SelectedLangId
        {
            get
            {
                return _selectedLangId;
            }
            set
            {
                _selectedLangId = value;
                SetCurrentCulture();
            }
        }


        public string this[string key]
        {
            get
            {
                return rm.GetString(key);
            }
        }


        public TranslationHelper()
        {
            // TODO:
            rm = new ResourceManager(typeof(Language));
            _selectedLangId = ci == null ? CultureInfo.CurrentCulture.Name : ci.Name;

            MessagingCenter.Subscribe<object, CultureInfo>(this, string.Empty, OnCurrentCultureChanged);
        }


        private void SetCurrentCulture()
        {
            if (_selectedLangId == null) _selectedLangId = string.Empty;

            ci = new CultureInfo(_selectedLangId);
            CultureInfo.CurrentUICulture = ci;
            CultureInfo.CurrentCulture = ci;
            Language.Culture = ci;

            MessagingCenter.Send<object, CultureInfo>(this, string.Empty, ci);
        }


        private void OnCurrentCultureChanged(object arg1, CultureInfo arg2)
        {
            OnPropertyChanged("Item");
        }
    }
}
