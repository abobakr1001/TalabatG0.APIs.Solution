using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;

namespace TalabatG0.APIs.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepostory<Product> genericRepo;

        public ProductsController(IGenericRepostory<Product> genericRepo)
        {
            this.genericRepo = genericRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>>  GetProduct()
        {
            var products = await genericRepo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var product =  await genericRepo.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
