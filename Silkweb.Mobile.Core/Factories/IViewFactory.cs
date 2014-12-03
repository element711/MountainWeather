using System;
using Xamarin.Forms;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.Core.Factories
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() 
            where TViewModel : class, IViewModel 
            where TView : Page;

        Page Resolve<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
    }
}

