using Microsoft.AspNetCore.Mvc;
using TalabatG0.APIs.Errors;

namespace TalabatG0.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            return NotFound(new ApiErrorResponse(code));
        }
    }
}
