using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoPedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Enumeradores;

namespace TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade
{
    public class Pedido : EntidadeBase
    {
        public int NumeroPedido { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;
        public EnumStatusPedido StatusPedido { get; private set; }
        public string? Observacoes { get; private set; }
        public Guid UsuarioCriadorId { get; private set; }
        public Usuario UsuarioCriador { get; private set; } = null!;
        public Guid? UsuarioAtualizadorId { get; private set; }
        public Usuario? UsuarioAtualizador { get; private set; }
        public List<ProdutoPedido> ProdutosPedidos { get; private set; } = new();
    }
}
