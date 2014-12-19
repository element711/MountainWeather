using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace Silkweb.Mobile.MountainWeather.Extensions
{
    [ContentProperty ("Source")]
    public class ImageResourceExtension : BindableObject, IMarkupExtension
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create<ImageResourceExtension,string>(p => p.Source, default(string));

        public string Source
        { 
            get { return (string)GetValue(SourceProperty); } 
            set { SetValue(SourceProperty, value); } 
        }


        public object ProvideValue (IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);
            return imageSource;
        }
    }
}

