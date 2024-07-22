using AutoMapper;
using TalabatG0.APIs.Dtos;
using TalabatG02.Core.Entities;

namespace TalabatG0.APIs.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(d => d.ProductType, o => o.MapFrom(p => p.ProductType.Name))
                .ForMember(d => d.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name));
        }
    }
}
