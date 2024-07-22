using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specification;

namespace TalabatG02.Repository
{
    public static class SpecificationEValutor<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria); // p=>p.Id

            query = spec.Inclodes.Aggregate(query, (currentQuery, IncludeExperssion) => currentQuery.Include(IncludeExperssion));
           
            return query;
        }
    }
}
