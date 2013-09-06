namespace Powa.Client.Core
{
    /// <summary>
    /// Interface that allows a test implementation of NavigationService to be used
    /// during unit and integration testing.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        ///   Navigates to the content specified by the uniform resource identifier (uri).
        /// </summary>
        /// <param name="pageUri"> The page uri. </param>
        void NavigateTo(string pageUri);

        /// <summary>
        ///   Navigates to the content specified by the uniform resource identifier (uri), 
        ///   replacing tokenised values with the specified arguments.
        /// </summary>
        /// <param name="pageUri"> The page uri. </param>
        /// <param name="args"> The args. </param>
        void NavigateTo(string pageUri, params object[] args);

        /// <summary>
        /// Navigates to the most recent entry in the back navigation history.
        /// </summary>
        void GoBack();
    }
}