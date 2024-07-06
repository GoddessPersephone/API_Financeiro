using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuaruio(string emailUsuaruio);
        Task<IList<Despesa>> ListarDespesasUsuaruioNaoPagasMesAnterior(string emailUsuaruio);

    }
}