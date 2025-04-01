using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Interfaces
{
    public interface IBranchOfficeUnitOfWork
    {
        Task<ActionResponse<BranchOffice>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync();
    }
}