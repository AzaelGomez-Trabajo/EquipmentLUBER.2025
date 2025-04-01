using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BranchOfficesController : GenericController<BranchOffice>
    {
        private readonly IBranchOfficeUnitOfWork _branchOfficeUnitOfWork;

        public BranchOfficesController(IGenericUnitOfWork<BranchOffice> unitOfWork, IBranchOfficeUnitOfWork branchOfficeUnitOfWork) : base(unitOfWork)
        {
            _branchOfficeUnitOfWork = branchOfficeUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _branchOfficeUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _branchOfficeUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }
    }
}