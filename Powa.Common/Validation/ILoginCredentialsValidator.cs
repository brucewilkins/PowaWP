using System.Collections.Generic;

namespace Powa.Common.Validation
{
    public interface ILoginCredentialsValidator
    {
        IEnumerable<ValidationResult> Validate(LoginCredentials credentials);
    }
}