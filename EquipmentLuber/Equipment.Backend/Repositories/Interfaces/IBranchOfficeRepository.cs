using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.Repositories.Interfaces
{
    public interface IBranchOfficeRepository
    {
        Task<ActionResponse<BranchOffice>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync();
    }
}
