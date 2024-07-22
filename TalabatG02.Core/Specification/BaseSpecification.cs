using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set ; } 
        public List<Expression<Func<T, object>>> Inclodes { get ; set ; } = new List<Expression<Func<T, object>>>(); // Inclode

        public BaseSpecification()
        {
            //Inclodes = new List<Expression<Func<T, object>>>();
        }

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;   
        }
    }
}
