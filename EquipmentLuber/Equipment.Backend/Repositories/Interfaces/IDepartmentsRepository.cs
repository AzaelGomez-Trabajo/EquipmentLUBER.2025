using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.Repositories.Interfaces
{
    public interface IDepartmentsRepository
    {
        Task<ActionResponse<Department>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Department>>> GetAsync();

        Task<ActionResponse<IEnumerable<Department>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
