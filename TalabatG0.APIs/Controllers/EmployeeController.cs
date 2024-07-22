using Microsoft.AspNetCore.Mvc;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specification;

namespace TalabatG0.APIs.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IGenericRepostory<Employee> empRepo;

        public EmployeeController(IGenericRepostory<Employee> empRepo)
        {
            this.empRepo = empRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var spec = new EmployeeSpecification();
            var employee = empRepo.GetAllWithSpecAsync(spec);
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById()
        {
            var spec = new EmployeeSpecification();
            var employee = empRepo.GetByIdWithSpecAsync(spec);
            return Ok(employee);
        }
    }
}
