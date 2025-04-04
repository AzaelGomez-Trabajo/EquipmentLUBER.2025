using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<ActionResponse<Employee>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

        Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
    }
}
