Implementation notes:

Structure:

- Powa.Client: The client application targeting WP8. 
               This project contains views, view models and application components.

- Powa.Client.UnitTests: This project contains (some example) unit tests for the logic in Powa.Client

- Powa.Common: A Portable Class Library targeting WP8 and WinRT demonstrating how business logic can be 
               shared between the different platforms.              


MVVM:

There are may frameworks that help implment the MVVM pattern e.g.: MvvmLight, Prism etc, each with their
own benefits and drawbacks. In this project I have chosen to use MvvmLight although typically for commercial
applications I prefer to use a custom solution and avoid dependencies on third party libraries due to
licensing, performance, maintenance and security related issues.
A custom solution would involve a more sophisticated and generic mechanism for coupling views and view models.


Testing:

I've provided some sample unit tests in Powa.Client.UnitTests for demonstration purposes. Although its pretty basic,
the intention is to demonstrate how code should be isolated into testable units with clear stages in the testing:
setting pre-conditions, executing the code, verifying expectations. All dependencies are mocked to ensure we are testing
just the intended logic.

There are no unit tests for Powa.Common however they would follow the same principle and have the same structure.

There should also be some form of integration (full stack, using no mock objcts) testing or acceptance testing, 
hopefully based on clearly defined acceptance criteria agreed on before implementation starts.

In ideal world, all tests would be run by some kind of Continuous Integration build process.


Frameworks/ Third party libraries used:

- Ninject: Used to provide dependency injection
- MVVM Light: Provides some basic components required for MVVM
- Moq: Allows the creation of mock objects to replace dependencies when unit testing 
- BindableApplicationBar: The standard AppBar is not bindable which results in non- MVVM structured code


Tools used:

- NuGet
- Resharper
- XAML Spy
