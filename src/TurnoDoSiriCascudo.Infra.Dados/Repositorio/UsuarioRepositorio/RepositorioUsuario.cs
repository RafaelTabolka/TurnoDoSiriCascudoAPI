using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.UsuarioRepositorio
{
    public class RepositorioUsuario(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Usuario>(contexto), IRepositorioUsuario;
}
