using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using Ninject;
using Powa.Client.Core;
using Powa.Client.Resources;
using Powa.Common.Validation;

namespace Powa.Client.ViewModels
{
    /// <summary>
    /// Contains commands that are bound to by the view.
    /// Logic is unit tested in Powa.Client.UnitTests project.
    /// </summary>
    public sealed class LoginViewModel : ViewModelBase
    {
        [Inject]
        public ILoginCredentialsValidator CredentialsValidator { private get; set; }

        public ICommand LoginCommand { get; private set; }
        public ICommand ContactCommand { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLogin);
            ContactCommand = new RelayCommand(OnContact);
        }

        /// <summary>
        /// Verifies that the credentials are valid according to the given spec,
        /// if so navigation to the content page is allowed, otherwise an error is displayed to the user.
        /// </summary>
        private void OnLogin()
        {
            var results = CredentialsValidator.Validate(new LoginCredentials(Username, Password));

            if (results.Any())
            {
                var message = results.Select(v => v.Message).Aggregate((a, b) => a + "\r\n\r\n" + b);
                MessageBox.Show(message, AppResources.DialogErrorCaption, MessageBoxButton.OK);
            }
            else
            {
                NavigationService.NavigateTo(PageUri.ContentPageUri);
            }
        }

        private void OnContact()
        {
            NavigationService.NavigateTo(PageUri.ContactPageUri);
        }
    }
}
