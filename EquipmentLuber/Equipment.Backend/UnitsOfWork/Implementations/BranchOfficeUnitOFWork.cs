using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class BranchOfficeUnitOfWork : GenericUnitOfWork<BranchOffice>, IBranchOfficeUnitOfWork
    {
        private readonly IBranchOfficeRepository _branchOfficeRepository;
        
        public BranchOfficeUnitOfWork(IGenericRepository<BranchOffice> repository, IBranchOfficeRepository branchOfficeRepository) : base(repository)
        {
            _branchOfficeRepository = branchOfficeRepository;
        }


        public override async Task<ActionResponse<BranchOffice>> GetAsync(int id) => await _branchOfficeRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync() => await _branchOfficeRepository.GetAsync();
    }
}
