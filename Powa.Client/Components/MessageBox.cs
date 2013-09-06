using System.Windows;

namespace Powa.Client.Components
{
    /// <summary>
    /// Wrapper around the native message box.
    /// </summary>
    public class MessageBox : IMessageBox
    {
        public MessageBoxResult Show(string messageBoxText)
        {
            return System.Windows.MessageBox.Show(messageBoxText);
        }

        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return System.Windows.MessageBox.Show(messageBoxText, caption, button);
        }
    }
}
