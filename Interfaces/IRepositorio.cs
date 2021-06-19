using System.Collections.Generic;

namespace DIO.series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorID(int Id);
        void Insere(T entidade);
        void Exclui(int Id);
        void Atualiza(int id, T entidade);
        int ProximoId();
        
    }
}