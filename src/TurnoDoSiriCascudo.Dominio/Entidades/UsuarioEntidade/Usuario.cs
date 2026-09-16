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
        public EnumPapelUsuario PapelUsuario { get; private set; }
        public List<Pedido> PedidosCadastrados { get; private set; } = new();
        public List<Produto> ProdutosCadastrados { get; private set; } = new();
        public List<Ingrediente> IngredientesCadastrados { get; private set; } = new();
        public List<Cliente> ClientesCadastrados { get; private set; } = new();

        public Usuario(string nomeUsuario)
        {
            Id = Guid.NewGuid();
            NomeUsuario = nomeUsuario;
            StatusUsuario = EnumStatusUsuario.Ativo;
            PapelUsuario = EnumPapelUsuario.Comum;
        }

        public void Atualizar(string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
        }

        public void DefineSenhaHash(string senhaHash)
        {
            Senha = senhaHash;
        }

        public void Ativar()
        {
            StatusUsuario = EnumStatusUsuario.Ativo;
        }

        public void Desativar()
        {
            StatusUsuario = EnumStatusUsuario.Inativo;
        }

        public void TornarAdmin()
        {
            PapelUsuario = EnumPapelUsuario.Administrador;
        }
    }
}
