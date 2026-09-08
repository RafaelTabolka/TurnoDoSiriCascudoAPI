using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar
{
    public class UsuarioCriarRequest : IRequest<UsuarioCriarResponse>
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}
