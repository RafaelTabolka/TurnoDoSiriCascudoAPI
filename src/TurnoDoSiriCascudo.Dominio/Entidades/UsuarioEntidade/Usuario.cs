using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Enumeradores;

namespace TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade
{
    public class Usuario : EntidadeBase
    {
        public string NomeUsuario { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public EnumStatusUsuario StatusUsuario { get; private set; }
        public List<Pedido> PedidosCadastrados { get; private set; } = new();
        public List<Produto> ProdutosCadastrados { get; private set; } = new();
        public List<Ingrediente> IngredientesCadastrados { get; private set; } = new();
        public List<Cliente> ClientesCadastrados { get; private set; } = new();
    }
}
