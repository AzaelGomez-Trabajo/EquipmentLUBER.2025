using Microsoft.AspNetCore.Mvc;
using Equipment.Shared.Entities;
using Equipment.Backend.UnitsOfWork.Interfaces;


namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentsController : GenericController<Department>
    {
        private readonly IDepartmentUnitOfWork _departmentUnitOfWork;

        public DepartmentsController(IGenericUnitOfWork<Department> unitOfWork, IDepartmentUnitOfWork departmentUnitOfWork) : base(unitOfWork)
        {
            _departmentUnitOfWork = departmentUnitOfWork;
        }

        public override async  Task<IActionResult> GetAsync()
        {
            var response = await _departmentUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _departmentUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound();
        }
    }
}
