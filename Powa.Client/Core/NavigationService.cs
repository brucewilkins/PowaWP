using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Powa.Client.Core
{
    /// <summary>
    /// Enables page navigtaion through the app.
    /// </summary>
    public class NavigationService : INavigationService
    {
        #region Implementation of INavigation

        /// <summary>
        ///   Navigates to the content specified by the uniform resource identifier (uri).
        /// </summary>
        /// <param name="pageUri"> The page uri. </param>
        public void NavigateTo(string pageUri)
        {
            var root = GetRootVisualElement();
            root.Navigate(new Uri(pageUri, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Navigates to the most recent entry in the back navigation history.
        /// </summary>
        public void GoBack()
        {
            var root = GetRootVisualElement();
            root.GoBack();
        }

        /// <summary>
        ///   Navigates to the content specified by the uniform resource identifier (uri), 
        ///   replacing tokenised values with the specified arguments.
        /// </summary>
        /// <param name="pageUri"> The page uri. </param>
        /// <param name="args"> The args. </param>
        public void NavigateTo(string pageUri, params object[] args)
        {
            if (args != null)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    if (args[i] != null)
                    {
                        var stringForm = args[i].ToString();
                        args[i] = Uri.EscapeDataString(stringForm);
                    }
                }
                pageUri = String.Format(pageUri, args);
            }

            NavigateTo(pageUri);
        }

        #endregion

        /// <summary>
        ///   Gets the application root visual element.
        /// </summary>
        /// <returns> A UIElement </returns>
        private PhoneApplicationFrame GetRootVisualElement()
        {
            if (Application.Current.RootVisual == null)
            {
                throw new InvalidOperationException("Application root visual element has not been set.");
            }

            return Application.Current.RootVisual as PhoneApplicationFrame;
        }
    }
}
