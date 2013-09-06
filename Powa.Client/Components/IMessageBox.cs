using System.Windows;

namespace Powa.Client.Components
{
    /// <summary>
    /// Interface that allows a test implementation of MessageBox to be used
    /// during unit and integration testing.
    /// </summary>
    public interface IMessageBox
    {
        MessageBoxResult Show(string messageBoxText);
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
    }
}