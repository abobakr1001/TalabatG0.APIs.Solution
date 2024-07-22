using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specification
{
    public class ProductSpecification:BaseSpecification<Product>
    {
        public ProductSpecification()
        {
            Inclodes.Add(P=>P.ProductType);
            Inclodes.Add(P => P.ProductBrand);
        }
        public ProductSpecification(int id):base(p=>p.Id == id)
        {
            Inclodes.Add(P => P.ProductType);
            Inclodes.Add(P => P.ProductBrand);
        }
    }
}
