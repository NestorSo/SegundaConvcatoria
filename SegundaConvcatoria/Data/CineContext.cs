using Microsoft.EntityFrameworkCore;
using SegundaConvcatoria.Models;

namespace SegundaConvcatoria.Data
{
    public class CineContext : DbContext
    {

        public CineContext(DbContextOptions<CineContext> options) : base(options)
        {

        }
         public DbSet<Pelicula> Peliculas { get; set; }
         public DbSet<Genero> Generos { get; set; }
    }
}
