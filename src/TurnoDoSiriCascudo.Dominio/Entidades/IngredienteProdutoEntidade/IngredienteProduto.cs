using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;

namespace TurnoDoSiriCascudo.Dominio.Entidades.IngredienteProdutoEntidade
{
    public class IngredienteProduto
    {
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; } = null!;
        public int QuantidadeIngrediente { get; private set; }
        public Guid IngredienteId { get; private set; }
        public Ingrediente Ingrediente { get; private set; } = null!;
    }
}
