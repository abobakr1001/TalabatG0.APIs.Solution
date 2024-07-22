using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specification
{
    public class EmployeeSpecification : BaseSpecification<Employee>
    {
        public EmployeeSpecification()
        {
            Inclodes.Add(P => P.Department);
           
        }
        public EmployeeSpecification(int id) : base(p => p.Id == id)
        {
            Inclodes.Add(P => P.Department);
            
        }
    }
}
