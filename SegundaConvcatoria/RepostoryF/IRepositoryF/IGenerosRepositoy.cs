using SegundaConvcatoria.RepostoryF.IRepositoryF;
using SegundaConvcatoria.Models;

namespace SegundaConvcatoria.RepostoryF.IRepositoryF
{
    public interface IGenerosRepositoy : IRepository <Genero>
    {
        Task<Genero> Update(Genero enity);
    }
}
