using Silkweb.Mobile.Core.Bootstrapping;
using Silkweb.Mobile.Core.Factories;
using Autofac;

namespace Silkweb.Mobile.Core.Tests.Mocks
{
    public class MockBootstrapper : AutofacBootstrapper
    {
        public IViewFactory ViewFactory { get; set; }

        public IContainer Container { get; set; }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<MockViewModel>();
            builder.RegisterType<MockView>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            ViewFactory = viewFactory;
            ViewFactory.Register<MockViewModel, MockView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            Container = container;
        }
    }
    
}
