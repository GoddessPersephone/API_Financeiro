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
        public async Task<IList<SistemaFinanceiro>> ListarSistemasUsuaruio(string emailUsuaruio)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.TabelaSistemaFinanceiro
                     join us in banco.TabelaUsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuaruio)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}