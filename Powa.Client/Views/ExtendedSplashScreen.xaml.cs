using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Powa.Client.Views
{
    public partial class ExtendedSplashScreen : PhoneApplicationPage
    {
        public ExtendedSplashScreen()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await Task.Delay(1800); // For demo purposes only!
            NavigationService.Navigate(new Uri(PageUri.LoginPageUri, UriKind.Relative));

            // Disallow backwards navigation to the ExtendedSplashScreen by 
            // removing the extended splash screen from the navigation stack
            for (int i = 0; i < NavigationService.BackStack.Count(); i++)
            {
                NavigationService.RemoveBackEntry();
            }
        }
    }
}