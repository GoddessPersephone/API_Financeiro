using Domain.Interfaces.ISistemaFinaceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositorioGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositorioSistemaFinanceiro()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public Task<IList<SistemaFinanceiro>> ListarSistemasUsuaruio(string emailUsuaruio)
        {
            throw new NotImplementedException();
        }
    }
}