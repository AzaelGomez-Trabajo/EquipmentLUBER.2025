using Microsoft.AspNetCore.Mvc;
using Equipment.Shared.Entities;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;


namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentsController : GenericController<Department>
    {
        private readonly IDepartmentsUnitOfWork _departmentsUnitOfWork;

        public DepartmentsController(IGenericUnitOfWork<Department> unitOfWork, IDepartmentsUnitOfWork departmentUnitOfWork) : base(unitOfWork)
        {
            _departmentsUnitOfWork = departmentUnitOfWork;
        }

        [HttpGet("full")]
        public override async  Task<IActionResult> GetAsync()
        {
            var response = await _departmentsUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _departmentsUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _departmentsUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _departmentsUnitOfWork.GetTotalPagesAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }
    }
}
