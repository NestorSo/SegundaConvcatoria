using SegundaConvcatoria.Data;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.RepostoryF.IRepositoryF;

namespace SegundaConvcatoria.RepostoryF
{
    public class GenerosRepository : Repository <Genero>, IGenerosRepositoy
    {
        private readonly CineContext _db;

        public GenerosRepository(CineContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Genero> Update(Genero enity)
        {
                _db.Generos.Update(enity);
                await _db.SaveChangesAsync();
                return enity;
        }
    }
}
