using System;
using System.Collections.Generic;
using pontos_turisticos_app.Interfaces;

namespace pontos_turisticos_app
{
    public class PontosRepositorio : IRepositorio<Pontos>
    {
        
        private List<Pontos> listaPontos = new List<Pontos>();
        public List<Pontos> List()
        {
            return listaPontos;
        }

        public Pontos ReturnById(int id)
        {
            return listaPontos[id];
        }

        public void Insert(Pontos objeto)
        {
            listaPontos.Add(objeto);
        }

        public void Delete(int id)
        {
            listaPontos[id].Delete();
        }

        public void Update(int id, Pontos objeto)
        {
            listaPontos[id] = objeto;
        }

        public int NextId()
        {
            return listaPontos.Count;
        }
    }
}