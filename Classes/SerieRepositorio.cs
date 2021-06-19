using System;
using System.Collections.Generic;
using DIO.series.Interfaces;

namespace DIO.series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> Listaserie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            Listaserie[id] = objeto;
        }

        public void Exclui(int Id)
        {
            Listaserie[Id].Exclui();
        }

        public void Insere(Serie objeto)
        {
                Listaserie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return Listaserie;
        }

        public int ProximoId()
        {
            return Listaserie.Count;
        }

        public Serie RetornaPorID(int Id)
        {
            return Listaserie[Id];
        }
    }
}