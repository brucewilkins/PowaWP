using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Powa.Client.Components;
using Powa.Client.Core;
using Powa.Client.ViewModels;

namespace Powa.Client.UnitTests.Core
{
    public class IocContainer
    {
        private readonly IKernel _kernel;

        public IocContainer()
        {
            _kernel = new StandardKernel();
            BindDependencies(_kernel);
        }

        private void BindDependencies(IKernel kernel)
        {
            // Application dependencies
            kernel.Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            kernel.Bind<IMessageBox>().To<MessageBox>().InSingletonScope();
            //kernel.Bind<ILoginCredentialsValidator>().To<LoginCredentialsValidator>().InSingletonScope();

            // ViewModels
            kernel.Bind<LoginViewModel>().ToSelf();
            kernel.Bind<ContentViewModel>().ToSelf();
            kernel.Bind<ContactViewModel>().ToSelf();
        }

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public void Release<T>(T instance)
        {
            _kernel.Release(instance);
        }
    }
}
