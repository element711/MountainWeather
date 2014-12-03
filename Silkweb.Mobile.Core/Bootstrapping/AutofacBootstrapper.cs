using System;
using Autofac;
using Silkweb.Mobile.Core.Factories;

namespace Silkweb.Mobile.Core.Bootstrapping
{
    public abstract class AutofacBootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            var container = builder.Build();
            var viewFactory = container.Resolve<IViewFactory>();

            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);

        protected abstract void ConfigureApplication(IContainer container);
    }
}

