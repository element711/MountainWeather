using System;
using Xamarin.Forms;

namespace Silkweb.Mobile.Core.Views
{
    public class TextCellExtended : TextCell
    {
        public static readonly BindableProperty ShowDisclosureProperty = 
            BindableProperty.Create<TextCellExtended,bool>(p => p.ShowDisclosure, default(bool));

        public bool ShowDisclosure
        { 
            get { return (bool)GetValue(ShowDisclosureProperty); } 
            set { SetValue(ShowDisclosureProperty, value); } 
        }
    }
}

