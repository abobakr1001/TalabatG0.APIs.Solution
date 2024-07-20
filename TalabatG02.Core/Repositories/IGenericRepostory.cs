using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Repositories
{
    public interface IGenericRepostory<T> where T : BaseEntity
    {  
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        
    }
}
