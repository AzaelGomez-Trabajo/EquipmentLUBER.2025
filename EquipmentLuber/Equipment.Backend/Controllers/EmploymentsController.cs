using Equipment.Backend.UnitsOfWork.Implementations;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmploymentsController : GenericController<Employment>
    {
        private readonly IEmploymentsUnitOfWork _employmentsUnitOfWork;

        public EmploymentsController(IGenericUnitOfWork<Employment> unitOfWork, IEmploymentsUnitOfWork employmentsUnitOfWork) : base(unitOfWork)
        {
            _employmentsUnitOfWork = employmentsUnitOfWork;
        }

        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _employmentsUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("totalpages")]
        public override async Task<IActionResult> GetTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _employmentsUnitOfWork.GetTotalPagesAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

    }
}
