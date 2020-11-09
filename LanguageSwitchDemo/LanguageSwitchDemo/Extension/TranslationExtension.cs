using LanguageSwitchDemo.Resource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageSwitchDemo.Extension
{
    public class TranslationExtension : BindableObject, IMarkupExtension<string>
    {
        public readonly static BindableProperty LangIdProperty = BindableProperty.Create("LangId", typeof(string), typeof(TranslationExtension), null, propertyChanged: OnLandIdPropertyChanged);
        public readonly static BindableProperty KeyProperty = BindableProperty.Create("Key", typeof(string), typeof(TranslationExtension), null, propertyChanged: OnKeyPropertyChanged);

        private BindableObject bindableObject;
        private BindableProperty bindableProperty;

        private string _key = string.Empty;
        private string _langId = string.Empty;
        private object _localContext;


        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }


        public string LangId
        {
            get
            {
                return _langId;
            }
            set
            {
                _langId = value;
                SetTargetPropertyText();
            }
        }


        public TranslationExtension()
        {
            // TODO:
            this.BindingContextChanged += TranslationExtension_BindingContextChanged;
        }


        protected string SetTargetPropertyText()
        {
            ResourceManager rm;
            CultureInfo ci;
            string _result;

            if (bindableObject == null) return string.Empty;
            _langId = _langId == null ? string.Empty : _langId;

            rm = new ResourceManager(typeof(Language));
            ci = new CultureInfo(_langId);
            Language.Culture = ci;

            _result = rm.GetString(_key, ci);
            bindableObject.SetValue(bindableProperty, _result);

            return _result;
        }

        private static void OnKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as TranslationExtension).Key = (string)newValue;
        }

        private static void OnLandIdPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as TranslationExtension).LangId = (string)newValue;
        }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            if (target == null) return string.Empty;

            bindableObject = (BindableObject)target.TargetObject;
            bindableProperty = (BindableProperty)target.TargetProperty;

            bindableObject.BindingContextChanged += TargetObject_BindingContextChanged;

            return SetTargetPropertyText();
        }

        private void TranslationExtension_BindingContextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            _localContext = this.BindingContext;
        }

        private void TargetObject_BindingContextChanged(object sender, EventArgs e)
        {
            BindableObject bo;

            if (_localContext != null) return;

            bo = (BindableObject)sender;
            BindingContext = bo.BindingContext;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
