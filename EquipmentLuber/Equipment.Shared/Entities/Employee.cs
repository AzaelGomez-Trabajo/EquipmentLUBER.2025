using Equipment.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class Employee : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        [Display(Name = "# de Empleado")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "Puesto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un {0}.")]
        public int EmploymentId { get; set; }

        public Employment? Employment { get; set; } = null!;

        public ICollection<FixedAsset>? FixedAssets { get; set; }

        [Display(Name = "Equipos")]
        public int FixedAssetsNumber => FixedAssets == null || FixedAssets.Count == 0 ? 0 : FixedAssets.Count;


    }
}