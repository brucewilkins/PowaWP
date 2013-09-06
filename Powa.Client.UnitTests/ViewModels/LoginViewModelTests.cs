using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Moq;
using Powa.Client.Components;
using Powa.Client.Core;
using Powa.Client.ViewModels;
using Powa.Common.Validation;

namespace Powa.Client.UnitTests.ViewModels
{
    [TestClass]
    public class LoginViewModelTests
    {
        // Unit test that verifies the happy flow logic for the login command,
        // dependencies are mocked so we can isolate just the logic under test.
        // The actual logic that determines whether the credentials are valid or not
        // should be tested by unit tests for the LoginCredentialsValidator component.
        // All unit tests will follow 3 steps: Arrange, Act, Assert. 
        [TestMethod]
        public void LoginWithValidCredentialsTest()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            var credentialsValidatorMock = new Mock<ILoginCredentialsValidator>();
            var messageBoxMock = new Mock<IMessageBox>();
            var navigationServiceMock = new Mock<INavigationService>();

            // Create a mock of the CredentialsValidator that returns no validation errors
            credentialsValidatorMock.Setup(c => c.Validate(It.IsAny<LoginCredentials>()))
                                    .Returns(new List<ValidationResult>())
                                    .Verifiable();

            // Create a mock for the MessageBox that will fail if the code incorrectly shows a message with validation errors
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>()))
                          .Throws(new Exception("Show() should not be called for valid credentials."));

            // Create a mock for the NavigationService that verifies that the code navigates (to the correct page) on login
            navigationServiceMock.Setup(n => n.NavigateTo("/Views/ContentPage.xaml"))
                                 .Verifiable();

            viewModel.CredentialsValidator = credentialsValidatorMock.Object;
            viewModel.MessageBox = messageBoxMock.Object;
            viewModel.NavigationService = navigationServiceMock.Object;

            // Act
            viewModel.LoginCommand.Execute(null);

            // Assert
            credentialsValidatorMock.VerifyAll();
            messageBoxMock.Verify(); // Don't VerifyAll() as the Show() method should not be called
            navigationServiceMock.VerifyAll();
        }

        // Unit test that verifies the logic for the login command when incorrect credentials are used
        [TestMethod]
        public void LoginWithInvalidCredentialsTest()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            var credentialsValidatorMock = new Mock<ILoginCredentialsValidator>();
            var messageBoxMock = new Mock<IMessageBox>();
            var navigationServiceMock = new Mock<INavigationService>();

            // Create a mock of the CredentialsValidator that returns validation errors
            credentialsValidatorMock.Setup(c => c.Validate(It.IsAny<LoginCredentials>()))
                                    .Returns(new List<ValidationResult>()
                                        {
                                            new ValidationResult(string.Empty, "Test message")
                                        })
                                    .Verifiable();

            // Create a mock for the MessageBox that will verify that the error message is shown
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>()))
                          .Verifiable();

            // Create a mock for the NavigationService that will fail if the code incorrectly navigates
            navigationServiceMock.Setup(n => n.NavigateTo(It.IsAny<string>()))
                                 .Throws(new Exception("NavigateTo() should not be called for invalid credentials."));

            viewModel.CredentialsValidator = credentialsValidatorMock.Object;
            viewModel.MessageBox = messageBoxMock.Object;
            viewModel.NavigationService = navigationServiceMock.Object;

            // Act
            viewModel.LoginCommand.Execute(null);

            // Assert
            credentialsValidatorMock.VerifyAll();
            messageBoxMock.VerifyAll();
            navigationServiceMock.Verify(); // Don't VerifyAll() as the NavigateTo() method should not be called
        }
    }
}
