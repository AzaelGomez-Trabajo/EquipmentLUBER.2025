﻿using Equipment.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class Employment : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Puesto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public int DepartmentId { get; set; }

        public Department? Department { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }

        [Display(Name = "Empleados")]
        public int EmployeesNumber => Employees == null || Employees.Count == 0 ? 0 : Employees.Count;

        public ICollection<FixedAsset>? FixedAssets { get; set; }

        [Display(Name = "Equipos")]
        public int FixedAssetsNumber => FixedAssets == null || FixedAssets.Count == 0 ? 0 : FixedAssets.Count;
    }
}