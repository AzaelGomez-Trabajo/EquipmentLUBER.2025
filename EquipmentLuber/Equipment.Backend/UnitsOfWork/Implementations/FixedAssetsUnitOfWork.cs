using Equipment.Backend.Repositories.Interfaces;
using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;

namespace Equipment.Backend.UnitsOfWork.Implementations
{
    public class FixedAssetsUnitOfWork : GenericUnitOfWork<FixedAsset>, IFixedAssetsUnitOfWork
    {
        private readonly IFixedAssetsRepository _fixedAssetsRepository;
        public FixedAssetsUnitOfWork(IGenericRepository<FixedAsset> repository, IFixedAssetsRepository fixedAssetsRepository) : base(repository)
        {
            _fixedAssetsRepository = fixedAssetsRepository;
        }
        
        public override async Task<ActionResponse<IEnumerable<FixedAsset>>> GetAsync(PaginationDTO pagination) => await _fixedAssetsRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _fixedAssetsRepository.GetTotalPagesAsync(pagination);
    }
}
