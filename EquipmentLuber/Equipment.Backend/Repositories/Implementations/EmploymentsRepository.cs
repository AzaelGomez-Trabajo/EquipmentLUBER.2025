using Equipment.Backend.Data;
using Equipment.Backend.Helpers;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class EmploymentsRepository : GenericRepository<Employment>, IEmploymentsRepository
    {
        private readonly DataContext _context;

        public EmploymentsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Employment>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employments
                .Where(e => e.DepartmentId == pagination.Id)
                .AsQueryable();
            return new ActionResponse<IEnumerable<Employment>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(e => e.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employments
                .Where(e => e.DepartmentId == pagination.Id)
                .AsQueryable();
            var count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }
    }
}