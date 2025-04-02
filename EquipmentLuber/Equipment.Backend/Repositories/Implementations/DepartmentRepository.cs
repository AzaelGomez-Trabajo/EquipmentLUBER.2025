using Equipment.Backend.Data;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<ActionResponse<Department>> GetAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Employments!)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (department is null)
            {
                return new ActionResponse<Department>
                {
                    WasSuccess = false,
                    Message = "No se encontro el departamento."
                };
            }
            return new ActionResponse<Department>
            {
                WasSuccess = true,
                Result = department
            };
        }

        public override async Task<ActionResponse<IEnumerable<Department>>> GetAsync()
        {
            var departments = await _context.Departments
                .Include(d => d.Employments)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Department>>
            {
                WasSuccess = true,
                Result = departments
            };
        }
    }
}
