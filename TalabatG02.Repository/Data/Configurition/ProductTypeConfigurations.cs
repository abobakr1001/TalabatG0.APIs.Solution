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
    internal class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
    {
        void IEntityTypeConfiguration<ProductType>.Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
