using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specification;

namespace TalabatG02.Core.Repositories
{
    public interface IGenericRepostory<T> where T : BaseEntity
    {  
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);


        #region Specifications
           Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
           Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);
        #endregion
       
    }
}
