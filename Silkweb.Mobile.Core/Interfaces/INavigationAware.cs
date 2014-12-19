using System;
using System.ComponentModel;

namespace Silkweb.Mobile.Core.Interfaces
{
    public interface INavigationAware
    {
        void NavigatedTo();

        void NavigatedFrom();
    }
}

