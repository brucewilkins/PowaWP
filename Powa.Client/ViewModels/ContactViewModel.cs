using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Tasks;
using Powa.Client.Core;
using Powa.Client.Resources;

namespace Powa.Client.ViewModels
{
    /// <summary>
    /// To test this ViewModel Environment.DeviceType, PhoneCallTask and EmailComposeTask
    /// should be replaced with custom dependencies that wrap the native component behaviour.
    /// </summary>
    public sealed class ContactViewModel : ViewModelBase
    {
        private const string _email = "zabrucewayne@yahoo.com";
        private const string _emailSubject = "Powa Windows Phone Challenge";
        private const string _phoneNumber = "0031612811434";
        private const string _phoneDisplayName = "Bruce Wilkins";

        public ICommand PhoneMeCommand { get; private set; }
        public ICommand EmailMeCommand { get; private set; }

        public string Email
        {
            get { return _email; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
        }

        public ContactViewModel()
        {
            PhoneMeCommand = new RelayCommand(OnPhoneMe);
            EmailMeCommand = new RelayCommand(OnEmailMe);
        }

        private void OnPhoneMe()
        {
            if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Emulator)
            {
                MessageBox.Show(AppResources.ContactPageEmulatorWarning);
                return;
            }

            var phoneTask = new PhoneCallTask
            {
                PhoneNumber = _phoneNumber, 
                DisplayName = _phoneDisplayName
            };

            phoneTask.Show();
        }

        private void OnEmailMe()
        {
            if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Emulator)
            {
                MessageBox.Show(AppResources.ContactPageEmulatorWarning);
                return;
            }

            var emailTask = new EmailComposeTask
            {
                To = _email, 
                Subject = _emailSubject
            };

            emailTask.Show();
        }
    }
}
