using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.Base;

namespace TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Task<List<Usuario>> ObterTodosOsUsuariosAsync();
        Task<Usuario?> ObterUsuarioPorIdAsync(Guid id);
    }
}
