using LanguageSwitchDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSwitchDemo.ViewModel
{
    public class SelectLanguage2PageViewModel : BaseViewModel
    {
        private LanguageItem _selectedLanguageItem = new LanguageItem();


        public LanguageItem SelectedLanguageItem
        {
            get
            {
                return _selectedLanguageItem;
            }
            set
            {
                _selectedLanguageItem = value;
                OnSelectedLanguageItemChanged();
                OnPropertyChanged("SelectedLanguageItem");
            }
        }


        public List<LanguageItem> LanguageList { get; set; }

        public SelectLanguage2PageViewModel()
        {
            // TODO:
            LanguageList = new List<LanguageItem>();
            SelectedLanguageItem.Id = string.IsNullOrEmpty(App.Config.SelectedLanguage) ? "en-US" : App.Config.SelectedLanguage;

            LanguageList.Add(new LanguageItem("en-US", "English"));
            LanguageList.Add(new LanguageItem("fr-FR", "Français"));
            LanguageList.Add(new LanguageItem("ja-JP", "日本語"));
            LanguageList.Add(new LanguageItem("zh-CN", "简体中文"));
            LanguageList.Add(new LanguageItem("zh-TW", "繁體中文"));
        }

        private void OnSelectedLanguageItemChanged()
        {
            App.Config.SelectedLanguage = _selectedLanguageItem.Id;
        }
    }
}
