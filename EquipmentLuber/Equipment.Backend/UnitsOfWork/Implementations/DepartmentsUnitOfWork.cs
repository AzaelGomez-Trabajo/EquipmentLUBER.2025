using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class DepartmentsUnitOfWork : GenericUnitOfWork<Department>, IDepartmentsUnitOfWork
    {
        private readonly IDepartmentsRepository _departmentRepository;

        public DepartmentsUnitOfWork(IGenericRepository<Department> repository, IDepartmentsRepository departmentRepository) : base(repository)
        {
            _departmentRepository = departmentRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Department>>> GetAsync() => await _departmentRepository.GetAsync();        

        public override async Task<ActionResponse<Department>> GetAsync(int id) => await _departmentRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Department>>> GetAsync(PaginationDTO pagination) => await _departmentRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _departmentRepository.GetTotalPagesAsync(pagination);
    }
}
