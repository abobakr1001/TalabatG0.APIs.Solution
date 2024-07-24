using Microsoft.AspNetCore.Mvc;
using TalabatG0.APIs.Errors;
using TalabatG02.Repository.Data;

namespace TalabatG0.APIs.Controllers
{
    public class BuggyController : ApiBaseController
    {
        private readonly StoreContext context;

        public BuggyController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet("NotFound")]
        public ActionResult getNotFound()
        {
            var product = context.Products.Find(100);
            if (product is null) return NotFound(new ApiErrorResponse(404));

            return Ok(product);
        }

        [HttpGet("ServerError")]
        public ActionResult getServerError()
        {
            var product = context.Products.Find(100);
            var returnProduct = product.ToString();

            return Ok(returnProduct);
        }


        [HttpGet("BadRequest")]
        public ActionResult getBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public ActionResult getBadRequest(int id)
        {
            return BadRequest();
        }
    }
}
