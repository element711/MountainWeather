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
    /// Collection class of IDataTemplateWrapper
    /// Enables xaml definitions of collections.
    /// </summary>
    public class DataTemplateCollection : ObservableCollection<IDataTemplateWrapper> { }
}
