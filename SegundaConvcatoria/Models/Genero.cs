using System.ComponentModel.DataAnnotations;

namespace SegundaConvcatoria.Models
{
    public class Genero
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string? Nombre { get; set; }

    }
}
