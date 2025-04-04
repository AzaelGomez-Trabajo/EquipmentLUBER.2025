using Equipment.Backend.Data;
using Equipment.Backend.Helpers;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class BranchOfficesRepository : GenericRepository<BranchOffice>, IBranchOfficesRepository
    {
        private readonly DataContext _context;

        public BranchOfficesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        // <resumen>
        public override async Task<ActionResponse<BranchOffice>> GetAsync(int id)
        {
            var branchOffice = await _context.BranchOffices
                .Include(bo => bo.Departments!)
                .ThenInclude(d => d.Employments!)
                .ThenInclude(e => e.Employees!)
                .FirstOrDefaultAsync(bo => bo.Id == id);
            if (branchOffice is null)
            {
                return new ActionResponse<BranchOffice>
                {
                    WasSuccess = false,
                    Message = "No se encontro la sucursal."
                };
            }
            return new ActionResponse<BranchOffice>
            {
                WasSuccess = true,
                Result = branchOffice
            };
        }

        // todas las sucursales
        public override async Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync()
        {
           var branchOffices = await _context.BranchOffices
                .OrderBy(bo => bo.Name)
                .ToListAsync();
            return new ActionResponse<IEnumerable<BranchOffice>>
            {
                WasSuccess = true,
                Result = branchOffices
            };
        }

        // todas las sucursales con paginacion
        public override async Task<ActionResponse<IEnumerable<BranchOffice>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.BranchOffices
                .Include(bo => bo.Departments!)
                .AsQueryable();
            var branchOffices = await queryable
                .OrderBy(bo => bo.Name)
                .Paginate(pagination)
                .ToListAsync();
            return new ActionResponse<IEnumerable<BranchOffice>>
            {
                WasSuccess = true,
                Result = branchOffices
            };
        }
    }
}
