using Equipment.Backend.Data;
using Equipment.Backend.Helpers;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<Employee>> GetAsync(int id)
        {
            var employee = await _context.Employees
                //.Include(e => e.Employment!)
                //.ThenInclude(e => e.Department!)
                //.ThenInclude(d => d.BranchOffice)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee is null)
            {
                return new ActionResponse<Employee>
                {
                    WasSuccess = false,
                    Message = "No se encontro el empleado."
                };
            }
            return new ActionResponse<Employee>
            {
                WasSuccess = true,
                Result = employee
            };
        }

        // todos los empleados
        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync()
        {
            var employees = await _context.Employees
                .OrderBy(e => e.Name)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = employees
            };
        }

        // todos los empleados con paginacion
        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees
                //.Include(e => e.Employment!)
                //.ThenInclude(e => e.Department!)
                //.ThenInclude(d => d.BranchOffice)
                //.Where(e => e.Id == pagination.Id)
                .AsQueryable();
            var employees = await queryable
                .OrderBy(e => e.Name)
                .Paginate(pagination)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = employees
            };
        }
    }
}
