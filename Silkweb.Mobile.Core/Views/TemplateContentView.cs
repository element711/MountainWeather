using System;
using Xamarin.Forms;

namespace Silkweb.Mobile.Core.Views
{
    public class TemplateContentView : ContentView
    {
        public TemplateContentView()
        {
            BindingContextChanged += HandleBindingContextChanged;
        }

        private void HandleBindingContextChanged (object sender, EventArgs e)
        {
            var content = TemplateSelector.ViewFor(BindingContext);
            Content = content;
            InvalidateLayout();
        }

        public static readonly BindableProperty TemplateSelectorProperty = 
            BindableProperty.Create<TemplateContentView, TemplateSelector>(x => x.TemplateSelector, default(TemplateSelector));

        public TemplateSelector TemplateSelector
        {
            get { return (TemplateSelector)GetValue(TemplateSelectorProperty); }
            set { SetValue(TemplateSelectorProperty, value); }
        }
    }
}

