using System.Collections.Generic;

namespace pontos_turisticos_app.Interfaces
{
    public interface IRepositorio<G>
    {
        List<G> List();
        G ReturnById(int id);
        void Insert(G entidade);
        void Delete(int id);
        void Update(int id, G entidade);
        int NextId();
    }
}