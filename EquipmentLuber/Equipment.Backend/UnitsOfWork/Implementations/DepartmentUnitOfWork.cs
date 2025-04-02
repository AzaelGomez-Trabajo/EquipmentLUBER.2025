using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class DepartmentUnitOfWork : GenericUnitOfWork<Department>, IDepartmentUnitOfWork
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentUnitOfWork(IGenericRepository<Department> repository, IDepartmentRepository departmentRepository) : base(repository)
        {
            _departmentRepository = departmentRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Department>>> GetAsync() => await _departmentRepository.GetAsync();        

        public override async Task<ActionResponse<Department>> GetAsync(int id) => await _departmentRepository.GetAsync(id);
    }
}
