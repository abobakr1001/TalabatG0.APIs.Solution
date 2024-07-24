namespace TalabatG0.APIs.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiErrorResponse(int statusCode, string? message =null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefualtMessageForStatusCode(statusCode);  
        }

        private string GetDefualtMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "bad request",
                401 => "authorized you are not",
                404 => "reponse not found",
                500 => "server  error",
                _ => null
            };

        }
    }
}
