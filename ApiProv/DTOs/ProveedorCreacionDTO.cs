using System.ComponentModel.DataAnnotations;

namespace ApiProv.DTOs
{
    public class ProveedorCreacionDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Ruc es requerido")]  
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El RUC debe tener 11 caracteres.")]
        public string Ruc { get; set; }
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; }
    }
}
