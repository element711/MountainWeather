using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Exceptions;

namespace Silkweb.Mobile.Core.Views
{

    /// <summary>
    /// Interface to enable DataTemplateCollection to hold
    /// typesafe instances of DataTemplateWrapper
    /// </summary>
    public interface IDataTemplateWrapper
    {
        bool IsDefault { get; set; }
        DataTemplate WrappedTemplate { get; set; }
        Type Type { get; }
    }
    
}
