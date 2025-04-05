using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FixedAssetsController : GenericController<FixedAsset>
    {
        private readonly IFixedAssetsUnitOfWork _fixedAssetsUnitOfWork;

        public FixedAssetsController(IGenericUnitOfWork<FixedAsset> unitOfWork, IFixedAssetsUnitOfWork fixedAssetsUnitOfWork) : base(unitOfWork)
        {
            _fixedAssetsUnitOfWork = fixedAssetsUnitOfWork;
        }

        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _fixedAssetsUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }
        public override async Task<IActionResult> GetTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _fixedAssetsUnitOfWork.GetTotalPagesAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }
    }
}
