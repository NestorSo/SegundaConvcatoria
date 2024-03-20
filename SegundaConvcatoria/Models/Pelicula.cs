using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundaConvcatoria.Models
{
    public class Pelicula
    {
       
        [Key]
        public int IdPelicula { get; set; }
        [StringLength(20)]
        public string? Nombre { get; set; }

        [StringLength(140)]
        public string? Descripcion { get; set; }
        [StringLength(20)]
        public string? Duracion { get; set; }
        [Required]
        public int Clasificacion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero? Generos { get; set; }
    }
}
