using Ninject;
using Powa.Client.Components;
using Powa.Client.ViewModels;
using Powa.Common.Validation;

namespace Powa.Client.Core
{
    /// <summary>
    /// The inversion of control container that enabled us to use a dependency injection framework
    /// to manage the construction and lifecycle of objects.
    /// The container is only exposed as IViewModelLocator to avoid getting into messy
    /// service locator anti-pattern issues.
    /// </summary>
    public class IocContainer : IViewModelLocator
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
            kernel.Bind<ILoginCredentialsValidator>().To<LoginCredentialsValidator>().InSingletonScope();
            
            // ViewModels
            kernel.Bind<LoginViewModel>().ToSelf();
            kernel.Bind<ContentViewModel>().ToSelf();
            kernel.Bind<ContactViewModel>().ToSelf();
        }

        public TViewModel Get<TViewModel>() where TViewModel : ViewModelBase
        {
            return _kernel.Get<TViewModel>();
        }

        public void Release<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            _kernel.Release(viewModel);
        }
    }
}
