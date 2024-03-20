using SegundaConvcatoria.RepostoryF.IRepositoryF;
using SegundaConvcatoria.Models;

namespace SegundaConvcatoria.RepostoryF.IRepositoryF
{
    public interface IPeliculasRepository : IRepository <Pelicula>
    {
        Task<Pelicula> Update(Pelicula enity);
    }
}
