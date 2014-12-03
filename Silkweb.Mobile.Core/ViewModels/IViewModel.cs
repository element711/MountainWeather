using System;
using System.ComponentModel;

namespace Silkweb.Mobile.Core.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }
    }
}

