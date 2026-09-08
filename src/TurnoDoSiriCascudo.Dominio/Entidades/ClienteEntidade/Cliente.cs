using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;

namespace TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade
{
    public class Cliente : EntidadeBase
    {
        public string NomeCliente { get; private set; } = string.Empty;
        public DateTime? DataUltimoPedido { get; private set; }
        public string Telefone { get; private set; } = string.Empty;
        public int QuantidadePedido { get; private set; }
        public string? Observacoes { get; private set; } = string.Empty;
        public Guid UsuarioCriadorId { get; private set; }
        public Usuario UsuarioCriador { get; private set; } = null!;
        public Guid? UsuarioAtualizadorId { get; private set; }
        public List<Pedido> Pedidos { get; private set; } = new();
    }
}
