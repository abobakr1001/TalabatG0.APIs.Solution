namespace TalabatG0.APIs.Errors
{
    public class ApiValidationErrorResponse:ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse():base(400)
        {

        }
    }
}
