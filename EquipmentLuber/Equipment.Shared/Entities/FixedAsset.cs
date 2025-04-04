using Equipment.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class FixedAsset : IEntityWithName
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Puesto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un {0}.")]
        public int EmploymentId { get; set; }

        public Employment? Employment { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }

        [Display(Name = "Empleado")]
        public int EmployeesNumber => Employees == null || Employees.Count == 0 ? 0 : Employees.Count;


    }
}
