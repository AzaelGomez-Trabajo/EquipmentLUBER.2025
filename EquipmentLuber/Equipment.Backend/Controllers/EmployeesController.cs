using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : GenericController<Employee>
    {
        public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
