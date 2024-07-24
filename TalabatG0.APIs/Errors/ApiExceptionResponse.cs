namespace TalabatG0.APIs.Errors
{
    public class ApiExceptionResponse:ApiErrorResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int statusCode,string? Message=null,string? Details=null):base(statusCode, Message)
        {
            this.Details = Details; 
        }
    }
}
