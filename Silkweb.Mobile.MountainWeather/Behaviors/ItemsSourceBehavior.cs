using System;
using Xamarin.Behaviors;
using Xamarin.Forms;
using System.Collections;

namespace Silkweb.Mobile.MountainWeather.Behaviors
{
    public class ItemsSourceBehavior : Behavior<StackLayout>
    {
        public static readonly BindableProperty ItemsSourceProperty = 
            BindableProperty.Create<ItemsSourceBehavior,IList>(p => p.ItemsSource, default(IList), BindingMode.TwoWay, null, ItemsSourceChanged);

        public IList ItemsSource
        { 
            get { return (IList)GetValue(ItemsSourceProperty); } 
            set { SetValue(ItemsSourceProperty, value); } 
        }

        public static readonly BindableProperty ItemTemplateProperty = 
            BindableProperty.Create<ItemsSourceBehavior,DataTemplate>(p => p.ItemTemplate, default(DataTemplate));

        public DataTemplate ItemTemplate
        { 
            get { return (DataTemplate)GetValue(ItemTemplateProperty); } 
            set { SetValue(ItemTemplateProperty, value); } 
        }

        static void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            var behavior = bindable as ItemsSourceBehavior;
            behavior.SetItems();
        }

        private void SetItems()
        {
            foreach (var item in ItemsSource)
                AssociatedObject.Children.Add(GetItemView(item));
        }

        private View GetItemView(object item)
        {
            var content = ItemTemplate.CreateContent();
            var view = content as View;
            view.BindingContext = item;
            return view;
        }

        protected override void OnAttach()
        {}

        protected override void OnDetach()
        {}
    }
}

