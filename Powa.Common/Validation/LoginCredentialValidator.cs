using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Powa.Common.Resources;

namespace Powa.Common.Validation
{
    public class LoginCredentialsValidator : ILoginCredentialsValidator
    {
        private const string UsernameRegexFormat = @"(^[a-zA-Z]{8,}$)";
        private const string PasswordRegexFormat = @"(^.{8,}$)";

        private readonly Regex _usernameRegex = new Regex(UsernameRegexFormat);
        private readonly Regex _passwordRegex = new Regex(PasswordRegexFormat);

        public IEnumerable<ValidationResult> Validate(LoginCredentials credentials)
        {
            var results = new List<ValidationResult>();

            results.Add(ValidateUsername(credentials.Username));
            results.Add(ValidatePassword(credentials.Password));

            return results.Where(r => r != null);
        }

        private ValidationResult ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username) ||
                !_usernameRegex.IsMatch(username))
            {
                // TODO: Get rid of magic strings
                return new ValidationResult("Username",  ResourceLoader.GetString("ValidationErrorUsername"));
            }

            return null;
        }

        private ValidationResult ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) ||
                !_passwordRegex.IsMatch(password))
            {
                // TODO: Get rid of magic strings
                return new ValidationResult("Password", ResourceLoader.GetString("ValidationErrorPassword"));
            }

            return null;
        }
    }
}
