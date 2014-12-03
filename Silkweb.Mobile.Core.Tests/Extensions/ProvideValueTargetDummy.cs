using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Silkweb.Mobile.Core.Tests.Extensions
{

    public class ProvideValueTargetDummy : IProvideValueTarget 
    {    

        public ProvideValueTargetDummy(object targetObject, object targetProperty) 
        {
            TargetObject = targetObject;
            TargetProperty = targetProperty;
        }    

        public object TargetObject { get;  private set; }

        public object TargetProperty { get;  private set; }
    }
    
}
