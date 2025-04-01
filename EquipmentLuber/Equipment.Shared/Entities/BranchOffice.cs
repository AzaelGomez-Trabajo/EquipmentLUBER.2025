using Equipment.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class BranchOffice : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Sucursal")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public ICollection<Department>? Departments { get; set; } = null!;

        [Display(Name = "Departamentos")]
        public int DepartmentsNumber => Departments == null || Departments.Count == 0 ? 0 : Departments.Count;
    }
}