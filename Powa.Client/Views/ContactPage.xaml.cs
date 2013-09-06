using Microsoft.Phone.Controls;
using Powa.Client.ViewModels;

namespace Powa.Client.Views
{
    public partial class ContactPage : PhoneApplicationPage
    {
        public ContactPage()
        {
            InitializeComponent();
            DataContext = (App.Current as App).ViewModelLocator.Get<ContactViewModel>();
        }
    }
}