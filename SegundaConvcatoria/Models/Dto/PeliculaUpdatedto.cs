using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SegundaConvcatoria.Models.Dto
{
    public class PeliculaUpdatedto
    {
        [Key]
        [Required]
        public int IdPelicula { get; set; }
        [StringLength(20)]
        public string? Nombre { get; set; }

        [StringLength(140)]
        public string? Descripcion { get; set; }
        [StringLength(20)]
        public string? Duracion { get; set; }
        [Required]
        public int Clasificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int IdGenero { get; set; }
       
    }
}
