using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Powa.Client.Core;
using Powa.Client.ViewModels;

namespace Powa.Client.Views
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (App.Current as App).ViewModelLocator.Get<LoginViewModel>();
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Clears the datacontext and releases the view model to ensure no data is cached
            // typically this can be done in a more generic way using a custom MVVM framework
            var viewModel = (ViewModelBase)DataContext;
            DataContext = null;
            (App.Current as App).ViewModelLocator.Release(viewModel);
        }
    }
}