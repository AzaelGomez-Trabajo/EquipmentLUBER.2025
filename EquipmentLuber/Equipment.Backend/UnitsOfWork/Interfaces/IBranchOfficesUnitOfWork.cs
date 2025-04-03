using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Interfaces
{
    public interface IBranchOfficesUnitOfWork
    {
        Task<ActionResponse<BranchOffice>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync();

        Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync(PaginationDTO pagination);
    }
}