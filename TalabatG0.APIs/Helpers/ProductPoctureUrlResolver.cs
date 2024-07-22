using AutoMapper;
using TalabatG0.APIs.Dtos;
using TalabatG02.Core.Entities;

namespace TalabatG0.APIs.Helpers
{
    public class ProductPoctureUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration configuration;

        public ProductPoctureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["ApiBaseUrl"]}{source.PictureUrl}";

            return string.Empty;
        }
    }

}
