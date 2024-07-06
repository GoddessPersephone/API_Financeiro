using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositorioGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositorioCategoria()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Categoria>> ListarCategoriasUsuaruio(string emailUsuaruio)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.TabelaSistemaFinanceiro
                     join c in banco.TabelaCategoria on s.Id equals c.IdSistema
                     join us in banco.TabelaUsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuaruio) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}