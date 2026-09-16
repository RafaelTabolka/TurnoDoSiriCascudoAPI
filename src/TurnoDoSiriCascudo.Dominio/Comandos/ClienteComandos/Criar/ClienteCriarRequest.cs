using MediatR;

namespace TurnoDoSiriCascudo.Dominio.Comandos.ClienteComandos.Criar
{
    public class ClienteCriarRequest : IRequest<ClienteCriarResponse>
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public Guid UsuarioCriadorId { get; set; }
    }
}
