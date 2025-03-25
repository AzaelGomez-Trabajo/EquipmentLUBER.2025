using Equipment.Backend.Data;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchOfficesController : ControllerBase
    {
        private readonly DataContext _context;

        public BranchOfficesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post1Async(BranchOffice branchOffice)
        {
            _context.Add(branchOffice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var branchOffices = await _context.BranchOffices.ToListAsync();
            return Ok(branchOffices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var branchOffice = await _context.BranchOffices.FindAsync(id);
            if (branchOffice == null)
            {
                return NotFound();
            }
            return Ok(branchOffice);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(BranchOffice branchOffice)
        {
            _context.Update(branchOffice);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var branchOffice = await _context.BranchOffices.FindAsync(id);
            if (branchOffice == null)
            {
                return NotFound();
            }

            _context.Remove(branchOffice);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
