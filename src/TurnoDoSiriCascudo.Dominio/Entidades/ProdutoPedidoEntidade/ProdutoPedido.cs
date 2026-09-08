using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;

namespace TurnoDoSiriCascudo.Dominio.Entidades.ProdutoPedidoEntidade
{
    public class ProdutoPedido
    {
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; } = null!;
        public int QuantidadeProduto { get; private set; }
        public Guid PedidoId { get; private set; }
        public Pedido Pedido { get; private set; } = null!;
    }
}
