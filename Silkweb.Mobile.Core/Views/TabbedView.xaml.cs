using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;

namespace Silkweb.Mobile.Core.Views
{	
    public partial class TabbedView : Grid
	{	
		public TabbedView ()
		{
			InitializeComponent ();
            items.SelectedItemChanged += HandleSelectedItemChanged;
		}

        private void HandleSelectedItemChanged(object sender, EventArgs e)
        {
            content.BindingContext = items.SelectedItem;
        }

        public static readonly BindableProperty ItemsSourceProperty = 
            BindableProperty.Create<TabbedView, IList>(p => p.ItemsSource, default(IList), BindingMode.TwoWay, null, ItemsSourceChanged);

        public IList ItemsSource
        { 
            get { return (IList)GetValue(ItemsSourceProperty); } 
            set { SetValue(ItemsSourceProperty, value); } 
        }

        public static readonly BindableProperty ItemTemplateProperty = 
            BindableProperty.Create<TabbedView, DataTemplate>(p => p.ItemTemplate, default(DataTemplate), BindingMode.TwoWay, null, ItemTemplateChanged);

        public DataTemplate ItemTemplate
        { 
            get { return (DataTemplate)GetValue(ItemTemplateProperty); } 
            set { SetValue(ItemTemplateProperty, value); } 
        }

        public static readonly BindableProperty TemplateSelectorProperty = 
            BindableProperty.Create<TabbedView,TemplateSelector>(p => p.TemplateSelector, default(TemplateSelector), BindingMode.Default, null, TemplateSelectorChanged);

        public TemplateSelector TemplateSelector
        { 
            get { return (TemplateSelector)GetValue(TemplateSelectorProperty); } 
            set { SetValue(TemplateSelectorProperty, value); } 
        }

        private static void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            var view = (TabbedView)bindable;
            view.SetItemsSource(newValue);
        }

        private void SetItemsSource(IList itemsSource)
        {
            items.ItemsSource = itemsSource;
        }

        private static void ItemTemplateChanged(BindableObject bindable, DataTemplate oldValue, DataTemplate newValue)
        {
            var view = (TabbedView)bindable;
            view.SetItemTemplate(newValue);
        }

        private void SetItemTemplate(DataTemplate itemTemplate)
        {
            items.ItemTemplate = itemTemplate;
        }

        private static void TemplateSelectorChanged(BindableObject bindable, TemplateSelector oldValue, TemplateSelector newValue)
        {
            var view = (TabbedView)bindable;
            view.SetTemplateSelector(newValue);
        }

        private void SetTemplateSelector(TemplateSelector templateSelector)
        {
            content.TemplateSelector = templateSelector;
        }
	}
}

