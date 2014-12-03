using System;
using System.Threading.Tasks;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.Core.Services
{
    public interface INavigator
    {
        Task<IViewModel> PopAsync();

        Task<IViewModel> PopModalAsync();

        Task PopToRootAsync();

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
            where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
            where TViewModel : class, IViewModel;
    }
}

