using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
    {
        private readonly IEmployeesRepository _employeeRepository;

        public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeesRepository) :base(repository)
        {
            _employeeRepository = employeesRepository;
        }

        public override async Task<ActionResponse<Employee>> GetAsync(int id) => await _employeeRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync() => await _employeeRepository.GetAsync();
        
        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await _employeeRepository.GetAsync(pagination);
    }
}
