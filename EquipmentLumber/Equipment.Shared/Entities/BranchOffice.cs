using System.ComponentModel.DataAnnotations;

namespace Equipment.Shared.Entities
{
    public class BranchOffice
    {
        public int Id { get; set; }

        [Display(Name = "Sucursal")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracterers")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;
    }
}