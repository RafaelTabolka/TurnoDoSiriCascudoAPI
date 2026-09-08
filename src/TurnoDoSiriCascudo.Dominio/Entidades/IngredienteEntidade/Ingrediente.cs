using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;

namespace TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade
{
    public class Ingrediente : EntidadeBase
    {
        public string NomeIngrediente { get; private set; } = string.Empty;
        public Guid UsuarioCriadorId { get; private set; }
        public Usuario UsuarioCriador { get; private set; } = null!;
        public Guid? UsuarioAtualizadorId { get; private set; }
        public Usuario? UsuarioAtualizador { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public List<IngredienteProduto> IngredientesProdutos { get; private set; } = null!;
    }
}
