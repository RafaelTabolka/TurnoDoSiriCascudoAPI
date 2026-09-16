using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Ativar
{
    public class UsuarioAtivarRequest(Guid id) : IRequest<UsuarioAtivarResponse>
    {
        public Guid Id { get; } = id;
    }
}
