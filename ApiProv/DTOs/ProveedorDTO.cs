using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProv.DTOs
{
    public class ProveedorDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
        public string Email { get; set; }
    }
}
