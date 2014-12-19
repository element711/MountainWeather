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

        public static readonly BindableProperty SelectedBackgroundColorProperty = 
            BindableProperty.Create<TextCellExtended,Color>(p => p.SelectedBackgroundColor, default(Color));

        public Color SelectedBackgroundColor
        { 
            get { return (Color)GetValue(SelectedBackgroundColorProperty); } 
            set { SetValue(SelectedBackgroundColorProperty, value); } 
        }

    }
}

