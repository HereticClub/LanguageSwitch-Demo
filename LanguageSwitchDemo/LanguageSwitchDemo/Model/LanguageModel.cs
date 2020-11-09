using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSwitchDemo.Model
{
    public class LanguageItem
    {
        public string Id { get; set; }

        public string DisplayText { get; set; }


        public LanguageItem()
        {
            // TODO:
        }


        public LanguageItem(string _id, string _displayText)
        {
            // TODO:

            Id = _id;
            DisplayText = _displayText;
        }
    }
}
