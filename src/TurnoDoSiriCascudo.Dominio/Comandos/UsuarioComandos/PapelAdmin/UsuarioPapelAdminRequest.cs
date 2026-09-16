using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.PapelAdmin
{
    public class UsuarioPapelAdminRequest(Guid id) : IRequest<UsuarioPapelAdminResponse>
    {
        public Guid Id { get; } = id;
    }
}
