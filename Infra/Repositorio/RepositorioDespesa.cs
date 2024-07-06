using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioDespesa : RepositorioGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositorioDespesa()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async  Task<IList<Despesa>> ListarDespesasUsuaruio(string emailUsuaruio)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.TabelaSistemaFinanceiro
                     join c in banco.TabelaCategoria on s.Id equals c.IdSistema
                     join us in banco.TabelaUsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.TabelaDespesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuaruio) && s.Mes == d.Mes && s.Ano == d.Ano
                     select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuaruioNaoPagasMesAnterior(string emailUsuaruio)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.TabelaSistemaFinanceiro
                     join c in banco.TabelaCategoria on s.Id equals c.IdSistema
                     join d in banco.TabelaDespesa on c.Id equals d.IdCategoria
                     join us in banco.TabelaUsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuaruio) && s.Mes < DateTime.Now.Month && !d.Pago
                     select d).AsNoTracking().ToListAsync();
            }
        }
    }
}