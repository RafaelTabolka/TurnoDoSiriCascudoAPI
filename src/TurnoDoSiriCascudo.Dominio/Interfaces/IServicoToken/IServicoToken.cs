using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;

namespace TurnoDoSiriCascudo.Dominio.Interfaces.IServicoToken
{
    public interface IServicoToken
    {
        string GerarToken(Usuario usuario);
    }
}
