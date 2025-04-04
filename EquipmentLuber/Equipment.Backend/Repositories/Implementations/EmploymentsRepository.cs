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

        public override async Task<ActionResponse<Employment>> GetAsync(int id)
        {
            var employment = await _context.Employments
                .Include(e => e.Employees!)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employment is null)
            {
                return new ActionResponse<Employment>
                {
                    WasSuccess = false,
                    Message = "No se encontro el empleo."
                };
            }
            return new ActionResponse<Employment>
            {
                WasSuccess = true,
                Result = employment
            };
        }

        public override async Task<ActionResponse<IEnumerable<Employment>>> GetAsync()
        {
            var employments = await _context.Employments
                .OrderBy(e => e.Name)
                .Include(e => e.Employees!)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Employment>>
            {
                WasSuccess = true,
                Result = employments
            };
        }

        public override async Task<ActionResponse<IEnumerable<Employment>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employments
                            .Include(e => e.Employees!)
                            .Where(e => e.DepartmentId == pagination.Id)
                            .AsQueryable();
            var employments = await queryable
                        .OrderBy(e => e.Name)
                        .Paginate(pagination)
                        .ToListAsync();
            return new ActionResponse<IEnumerable<Employment>>
            {
                WasSuccess = true,
                Result = employments
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