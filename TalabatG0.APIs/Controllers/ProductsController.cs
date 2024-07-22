using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatG0.APIs.Dtos;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specification;

namespace TalabatG0.APIs.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepostory<Product> genericRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepostory<Product> genericRepo,IMapper mapper)
        {
            this.genericRepo = genericRepo;
            this.mapper = mapper;
        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDTO>>>  GetProduct()
        {
            var spec = new ProductSpecification();
            var products = await genericRepo.GetAllWithSpecAsync(spec);
            var mapped = mapper.Map<IEnumerable<Product> ,IEnumerable<ProductToReturnDTO>>(products);
           // var products = await genericRepo.GetAllAsync();
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProdut(int id)
        {
            var spec = new ProductSpecification(id);
            var products = await genericRepo.GetByIdWithSpecAsync(spec);

            var mapped = mapper.Map<Product, ProductToReturnDTO>(products);

            
            return Ok(mapped);
        }
    }
}
