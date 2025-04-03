using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class EmploymentsUnitOfWork : GenericUnitOfWork<Employment>, IEmploymentsUnitOfWork
    {
        private readonly IEmploymentsRepository _employmentRepository;

        public EmploymentsUnitOfWork(IGenericRepository<Employment> repository, IEmploymentsRepository employmentRepository) : base(repository)
        {
            _employmentRepository = employmentRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Employment>>> GetAsync(PaginationDTO pagination) => await _employmentRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _employmentRepository.GetTotalPagesAsync(pagination);
    }
}
