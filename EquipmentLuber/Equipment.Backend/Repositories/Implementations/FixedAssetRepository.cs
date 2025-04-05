using Equipment.Backend.Data;
using Equipment.Backend.Helpers;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class FixedAssetRepository : GenericRepository<FixedAsset>, IFixedAssetsRepository
    {
        private readonly DataContext _context;
        public FixedAssetRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<ActionResponse<IEnumerable<FixedAsset>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.FixedAssets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }
            var fixedAssets = await queryable
                .OrderBy(e => e.Name)
                .Paginate(pagination)
                .ToListAsync();
            return new ActionResponse<IEnumerable<FixedAsset>>
            {
                WasSuccess = true,
                Result = fixedAssets
            };
        }
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryble = _context.FixedAssets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryble = queryble.Where(e => e.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }
            var count = await queryble.CountAsync();
            var totalPages = (int)Math.Ceiling((double)count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }


    }
}
