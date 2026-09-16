using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Desativar
{
    public class UsuarioDesativarRequest(Guid id) : IRequest<UsuarioDesativarResponse>
    {
        public Guid Id { get; } = id;
    }
}
