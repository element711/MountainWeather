using System;
using System.ComponentModel;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.Core.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged, INavigationAware
    {
        string Title { get; set; }
    }
}

