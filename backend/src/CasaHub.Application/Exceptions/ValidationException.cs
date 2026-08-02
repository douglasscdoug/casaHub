namespace CasaHub.Application.Exceptions
{
    public record ValidationError(string Field, string Message);
    
    public class ValidationException(IEnumerable<ValidationError> errors) : AppException("Revise os dados informados.")
    {
        public IReadOnlyCollection<ValidationError> Errors { get; } = errors.ToArray();
    }
}