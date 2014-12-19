using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections;
using System.Windows.Input;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.Core.Views
{
    public partial class ItemsView : ScrollView
    {
        private readonly ICommand _selectedCommand;

        public ItemsView()
        {
            InitializeComponent();

            _selectedCommand = new Command<object>( item =>  SelectedItem = item );
        }

        public event EventHandler SelectedItemChanged;

        public static readonly BindableProperty ItemsSourceProperty = 
            BindableProperty.Create<ItemsView,IList>(p => p.ItemsSource, default(IList), BindingMode.TwoWay, null, ItemsSourceChanged);

        public IList ItemsSource
        { 
            get { return (IList)GetValue(ItemsSourceProperty); } 
            set { SetValue(ItemsSourceProperty, value); } 
        }

        public static readonly BindableProperty SelectedItemProperty = 
            BindableProperty.Create<ItemsView,object>(p => p.SelectedItem, default(object), BindingMode.TwoWay, null, OnSelectedItemChanged);

        public object SelectedItem
        { 
            get { return (object)GetValue(SelectedItemProperty); } 
            set { SetValue(SelectedItemProperty, value); } 
        }

        public static readonly BindableProperty ItemTemplateProperty = 
            BindableProperty.Create<ItemsView,DataTemplate>(p => p.ItemTemplate, default(DataTemplate));

        public DataTemplate ItemTemplate
        { 
            get { return (DataTemplate)GetValue(ItemTemplateProperty); } 
            set { SetValue(ItemTemplateProperty, value); } 
        }

        private static void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            var itemsLayout = (ItemsView)bindable;
            itemsLayout.SetItems();
        }

        private void SetItems()
        {
            stackLayout.Children.Clear();

            if (ItemsSource == null)
                return;

            foreach (var item in ItemsSource)
                stackLayout.Children.Add(GetItemView(item));

            SelectedItem = ItemsSource.Cast<object>().FirstOrDefault();
        }

        private View GetItemView(object item)
        {
            var content = ItemTemplate.CreateContent();
            var view = content as View;
            view.BindingContext = item;

            view.GestureRecognizers.Add(new TapGestureRecognizer
                { 
                    Command = _selectedCommand, 
                    CommandParameter = item as object
                });

            return view;
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var itemsView = (ItemsView)bindable;

            if (newValue == oldValue)
                return;

            var items = itemsView.ItemsSource.OfType<ISelectable>();

            foreach (var item in items)
                item.IsSelected = item == newValue;

            var handler = itemsView.SelectedItemChanged;
            if (handler != null)
                handler(itemsView, EventArgs.Empty);
        }
    }
}

