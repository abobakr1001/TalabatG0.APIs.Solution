using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Repository.Data;

namespace TalabatG02.Repository
{
    public class GenericRepostory<T> : IGenericRepostory<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public GenericRepostory(StoreContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>)await context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
            return await context.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
