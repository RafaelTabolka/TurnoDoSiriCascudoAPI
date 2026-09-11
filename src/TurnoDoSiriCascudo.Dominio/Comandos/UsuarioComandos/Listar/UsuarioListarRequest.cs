using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Listar
{
    public class UsuarioListarRequest : IRequest<List<UsuarioListarResponse>>;
}
