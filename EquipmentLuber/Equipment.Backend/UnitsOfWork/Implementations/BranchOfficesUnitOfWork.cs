using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class BranchOfficesUnitOfWork : GenericUnitOfWork<BranchOffice>, IBranchOfficesUnitOfWork
    {
        private readonly IBranchOfficesRepository _branchOfficeRepository;
        
        public BranchOfficesUnitOfWork(IGenericRepository<BranchOffice> repository, IBranchOfficesRepository branchOfficeRepository) : base(repository)
        {
            _branchOfficeRepository = branchOfficeRepository;
        }


        public override async Task<ActionResponse<BranchOffice>> GetAsync(int id) => await _branchOfficeRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync() => await _branchOfficeRepository.GetAsync();
        
        public override async Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync(PaginationDTO pagination) => await _branchOfficeRepository.GetAsync(pagination);
    }
}
