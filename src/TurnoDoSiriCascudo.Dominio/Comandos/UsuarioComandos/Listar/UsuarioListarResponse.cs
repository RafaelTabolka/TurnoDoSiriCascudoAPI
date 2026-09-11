using TurnoDoSiriCascudo.Dominio.Enumeradores;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Listar
{
    internal class UsuarioListarResponse(
        Guid id,
        string nomeUsuario,
        EnumStatusUsuario statusUsuario,
        List<PedidoCadastradoDto> pedidosCadastrados,
        List<ProdutoCadastradoDto> produtosCadastrados,
        List<IngredienteCadastradoDto> ingredientesCadastrados,
        List<ClienteCadastradoDto> clientesCadastrados
    )
    {
        public Guid Id { get; } = id;
        public string NomeUsuario { get; } = nomeUsuario;
        public EnumStatusUsuario StatusUsuario { get; } = statusUsuario;
        public List<PedidoCadastradoDto> PedidosCadastrados { get; } = pedidosCadastrados;
        public List<ProdutoCadastradoDto> ProdutosCadastrados { get; } = produtosCadastrados;
        public List<IngredienteCadastradoDto> IngredientesCadastrados { get; } = ingredientesCadastrados;
        public List<ClienteCadastradoDto> ClientesCadastrados { get; } = clientesCadastrados;

    }

    internal class PedidoCadastradoDto(
        int numeroPedido,
        EnumStatusPedido statusPedido,
        string? observacoes
    )
    {
        public int NumeroPedido { get; } = numeroPedido;
        public EnumStatusPedido StatusPedido { get; } = statusPedido;
        public string? Observacoes { get; } = observacoes;
    }

    internal class ProdutoCadastradoDto(string nomeProduto)
    {
        public string NomeProduto { get; } = nomeProduto;
    }

    internal class IngredienteCadastradoDto(string nomeIngrediente, int quantidadeEstoque)
    {
        public string NomeIngrediente { get; } = nomeIngrediente;
        public int QuantidadeEstoque { get; } = quantidadeEstoque;
    }

    internal class ClienteCadastradoDto(
        string nomeCliente,
        DateTime? dataUltimoPedido,
        int quantidadePedidosFeitos,
        string? observacoes
    )
    {
        public string NomeCliente { get; } = nomeCliente;
        public DateTime? DataUltimoPedido { get; } = dataUltimoPedido;
        public int QuantidadePedidosFeitos { get; } = quantidadePedidosFeitos;
        public string? Observacoes { get; } = observacoes;
    }
}
