﻿using Equipment.Backend.Data;
using Equipment.Backend.Helpers;
using Equipment.Backend.Repositories.Interfaces;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Equipment.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Repositories.Implementations
{
    public class DepartmentsRepository : GenericRepository<Department>, IDepartmentsRepository
    {
        private readonly DataContext _context;

        public DepartmentsRepository(DataContext context) : base(context)
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
                .OrderBy(d => d.Name)
                .Include(d => d.Employments)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Department>>
            {
                WasSuccess = true,
                Result = departments
            };
        }

        public override async Task<ActionResponse<IEnumerable<Department>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Departments
                .Include(d => d.Employments)
                .Where(bo => bo.BranchOfficeId == pagination.Id)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(d => d.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }
            var departments = await queryable
                    .OrderBy(d => d.Name)
                    .Paginate(pagination)
                    .ToListAsync();
            return new ActionResponse<IEnumerable<Department>>
            {
                WasSuccess = true,
                Result = departments
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Departments
                .Where(bo => bo.BranchOffice!.Id == pagination.Id)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(d => d.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }
            var count = await queryable.CountAsync();
            var totalPages = (int)Math.Ceiling((double)count / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = totalPages
            };
        }
    }
}