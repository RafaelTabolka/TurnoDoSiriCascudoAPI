using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoPedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;

namespace TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade
{
    public class Produto : EntidadeBase
    {
        public string NomeProduto { get; private set; } = string.Empty;
        public Guid UsuarioCriadorId { get; private set; }
        public Usuario UsuarioCriador { get; private set; } = null!;
        public Guid? UsuarioAtualizadorId { get; private set; }
        public Usuario? UsuarioAtualizador { get; private set; }
        public List<ProdutoPedido> ProdutosPedidos { get; private set; } = new();
        public List<IngredienteProduto> IngredientesProdutos { get; private set; } = new();
    }
}
