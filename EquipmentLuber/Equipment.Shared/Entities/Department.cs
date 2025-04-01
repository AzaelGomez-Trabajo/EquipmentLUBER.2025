using Equipment.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class Department : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public int BranchOfficeId { get; set; }

        public BranchOffice? BranchOffice { get; set; }

        public ICollection<Employment>? Employments { get; set; } = null!;

        [Display(Name = "Puestos")]
        public int EmploymentsNumber => Employments == null || Employments.Count == 0 ? 0 : Employments.Count;
    }
}