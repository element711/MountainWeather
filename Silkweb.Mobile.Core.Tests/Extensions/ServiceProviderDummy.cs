using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Silkweb.Mobile.Core.Tests.Extensions
{
    public class ServiceProviderDummy : IServiceProvider 
    {
        private readonly IProvideValueTarget _provideValueTargetContext;

        public ServiceProviderDummy(IProvideValueTarget provideValueTargetContext) 
        {
            _provideValueTargetContext = provideValueTargetContext;
        }    

        public object GetService(Type serviceType) 
        {
            object service = null;

            if (serviceType.Equals(typeof(IProvideValueTarget))) 
            {
                service = _provideValueTargetContext;
            }
            return service;
        }
    }
    
}
