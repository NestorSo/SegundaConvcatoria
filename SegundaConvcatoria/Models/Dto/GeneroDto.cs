using System.ComponentModel.DataAnnotations;

namespace SegundaConvcatoria.Models.Dto
{
    public class GeneroDto
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string? Nombre { get; set; }
    }
}
