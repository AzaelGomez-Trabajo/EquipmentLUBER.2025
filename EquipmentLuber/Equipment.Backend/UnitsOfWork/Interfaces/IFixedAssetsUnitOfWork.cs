using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Interfaces
{
    public interface IFixedAssetsUnitOfWork
    {
        Task<ActionResponse<IEnumerable<FixedAsset>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
