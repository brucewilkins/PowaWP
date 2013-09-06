
namespace Powa.Client.Core
{
    /// <summary>
    /// Exposes Get() and Release() methods on the IocContainer (or which ever component implements this interface)
    /// allowing Pages to set their data context to the appropriate view model.
    /// </summary>
    public interface IViewModelLocator
    {
        TViewModel Get<TViewModel>() where TViewModel : ViewModelBase;
        void Release<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
    }
}