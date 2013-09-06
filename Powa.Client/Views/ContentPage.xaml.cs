using Microsoft.Phone.Controls;
using Powa.Client.ViewModels;

namespace Powa.Client.Views
{
    public partial class ContentPage : PhoneApplicationPage
    {
        public ContentPage()
        {
            InitializeComponent();
            DataContext = (App.Current as App).ViewModelLocator.Get<ContentViewModel>();
        }
    }
}