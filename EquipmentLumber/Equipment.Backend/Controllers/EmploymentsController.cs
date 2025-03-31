using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmploymentsController : GenericController<Employment>
    {
        public EmploymentsController(IGenericUnitOfWork<Employment> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
