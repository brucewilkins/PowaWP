namespace Powa.Common.Validation
{
    public class ValidationResult
    {
        public string Message { get; private set; }
        public string Field { get; private set; }

        public ValidationResult(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}