using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : GenericController<Employee>
    {
        private readonly IEmployeesUnitOfWork _employeesUnitOfWork;

        public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork, IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
        {
            _employeesUnitOfWork = employeesUnitOfWork;
        }
        
        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _employeesUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _employeesUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _employeesUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }


    }
}
