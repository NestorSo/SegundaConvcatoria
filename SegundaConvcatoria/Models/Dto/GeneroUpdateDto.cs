using System.ComponentModel.DataAnnotations;

namespace SegundaConvcatoria.Models.Dto
{
    public class GeneroUpdateDto
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [StringLength(20)]
        [Required]
        public string? Nombre { get; set; }
    }
}
