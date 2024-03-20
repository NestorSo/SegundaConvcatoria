using SegundaConvcatoria.Data;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.RepostoryF.IRepositoryF;

namespace SegundaConvcatoria.RepostoryF
{
    public class PeliculasRepository : Repository<Pelicula>, IPeliculasRepository
    {
        private readonly CineContext _db;

        public PeliculasRepository(CineContext db) : base(db)
        {
            _db = db;

        }
        public async Task<Pelicula> Update(Pelicula enity)
        {
            _db.Peliculas.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
