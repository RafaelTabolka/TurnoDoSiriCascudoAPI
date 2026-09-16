using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Atualizar
{
    public class UsuarioAtualizarRequest : IRequest<UsuarioAtualizarResponse>
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
    }
}
