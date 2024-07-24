using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using TalabatG0.APIs.Errors;

namespace TalabatG0.APIs.Middlewars
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext content)
        {
            try
            {
                await next.Invoke(content);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                content.Response.ContentType = "application/json";
                content.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                //var options = new JsonSerializerOptions()
                //{
                //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                //};

                var response = env.IsDevelopment() ?
                            new ApiExceptionResponse((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString())
                            :
                            new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

                var json = JsonSerializer.Serialize(response);  

                await content.Response.WriteAsync(json);
                         

            }
        }
       
    }
}
