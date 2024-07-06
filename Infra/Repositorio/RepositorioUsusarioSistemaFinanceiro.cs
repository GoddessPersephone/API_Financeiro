using Domain.Interfaces.IUsuarioSistemaFinaceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsusarioSistemaFinanceiro : RepositorioGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositorioUsusarioSistemaFinanceiro()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarSistemasUsuaruio(int idSistema)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                     banco.TabelaUsuarioSistemaFinanceiro
                    .Where(s => s.IdSistema == idSistema).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuaruioPorEmail(string emailUsuaruio)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                     banco.TabelaUsuarioSistemaFinanceiro.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuaruio));
            }
        }

        public async Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                banco.TabelaUsuarioSistemaFinanceiro
               .RemoveRange(usuarios);
                await banco.SaveChangesAsync();
            }
        }
    }
}