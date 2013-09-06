using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Powa.Client.Core;
using Powa.Client.Resources;

namespace Powa.Client.ViewModels
{
    /// <summary>
    /// Simple view model that contains commands that are bound to by the view
    /// </summary>
    public sealed class ContentViewModel : ViewModelBase
    {
        public ICommand UserActionCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public ContentViewModel()
        {
            UserActionCommand = new RelayCommand(OnUserAction);
            LogoutCommand = new RelayCommand(OnLogout);
        }

        private void OnUserAction()
        {
            MessageBox.Show(AppResources.UserActionMessageText);
        }

        private void OnLogout()
        {
            var result = MessageBox.Show(AppResources.LogoutDialogMessage,
                                         AppResources.LogoutDialogCaption,
                                         MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                NavigationService.GoBack();
            }
        }
    }
}
