﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Repository.Configurition
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(P=>P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired();
            builder.Property(P => P.PictureUrl).IsRequired();
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(18,2)");


            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(p => p.ProductType)
               .WithMany().HasForeignKey(p => p.ProductTypeId);    
        }
    }
}
