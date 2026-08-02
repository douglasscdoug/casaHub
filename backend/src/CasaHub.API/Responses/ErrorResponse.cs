namespace CasaHub.API.Responses
{
    public class ErrorResponse
    {
        public int Status { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
        public string? TraceId { get; set; }

        public IEnumerable<ErrorDetail>? Errors { get; set; }
    }

    public class ErrorDetail
    {
        public string? Field { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}