using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Repository.Configurition
{
    public class ProductBrandConfigurations : IEntityTypeConfiguration<ProductBrand>
    {
        void IEntityTypeConfiguration<ProductBrand>.Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
