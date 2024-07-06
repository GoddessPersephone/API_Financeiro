using Domain.Interfaces.IUsuarioSistemaFinaceiro;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioUsusarioSistemaFinanceiro : RepositorioGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        public Task<IList<UsuarioSistemaFinanceiro>> ListarSistemasUsuaruio(int idSistema)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioSistemaFinanceiro> ObterUsuaruioPorEmail(string emailUsuaruio)
        {
            throw new NotImplementedException();
        }

        public Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            throw new NotImplementedException();
        }
    }
}