using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {

            if (!context.ProductBrands.Any())
            {
                 var brandData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/brands.json");
                 var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

               if (brands?.Count > 0)
               {
                  foreach (var brnd in brands)
                    await context.ProductBrands.AddAsync(brnd);
                    await context.SaveChangesAsync();
                }
            }


            if (!context.ProductTypes.Any())
            {
                var brandData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/types.json");
                var brands = JsonSerializer.Deserialize<List<ProductType>>(brandData);

                if (brands?.Count > 0)
                {
                    foreach (var brnd in brands)
                        await context.ProductTypes.AddAsync(brnd);
                    await context.SaveChangesAsync();
                }
            }


            if (!context.Products.Any())
            {
                var brandData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/products.json");
                var brands = JsonSerializer.Deserialize<List<Product>>(brandData);

                if (brands?.Count > 0)
                {
                    foreach (var brnd in brands)
                        await context.Products.AddAsync(brnd);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
