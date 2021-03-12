using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeSeries.Modelos.Interface;

namespace CadastroDeSeries.Modelos
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Exclui();
        }

        public void Insere(Serie objeto)
        {
            listaSeries.Add(objeto);
        }
        public void InsereEstrela(int id, int estrelasQuantidade) 
        {
            listaSeries[id].InsereEstrela(estrelasQuantidade);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}
