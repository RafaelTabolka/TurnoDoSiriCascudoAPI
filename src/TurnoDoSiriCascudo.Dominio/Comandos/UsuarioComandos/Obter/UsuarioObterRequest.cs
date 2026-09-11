using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Obter
{
    public class UsuarioObterRequest(Guid id) : IRequest<UsuarioObterResponse>
    {
        public Guid Id { get; } = id;
    }
}
