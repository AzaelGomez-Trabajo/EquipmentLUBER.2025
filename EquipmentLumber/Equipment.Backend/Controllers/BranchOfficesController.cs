﻿using Equipment.Backend.UnitsOfWork.Interfaces;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BranchOfficesController : GenericController<BranchOffice>
    {
        public BranchOfficesController(IGenericUnitOfWork<BranchOffice> unitOfWork) : base(unitOfWork)
        {
        }
    }
}