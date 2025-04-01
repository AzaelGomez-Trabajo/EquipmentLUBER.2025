using Microsoft.AspNetCore.Mvc;
using Equipment.Shared.Entities;
using Equipment.Backend.UnitsOfWork.Interfaces;


namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentsController : GenericController<Department>
    {
        public DepartmentsController(IGenericUnitOfWork<Department> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
