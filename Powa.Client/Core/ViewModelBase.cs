using Ninject;
using Powa.Client.Components;
using Powa.Client.Resources;

namespace Powa.Client.Core
{
    /// <summary>
    /// Provides a common base class for view models for common logic and dependencies
    /// </summary>
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        [Inject]
        public INavigationService NavigationService { protected get; set; }

        [Inject]
        public IMessageBox MessageBox { protected get; set; }
    }
}
