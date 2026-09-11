using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Obter
{
    internal class UsuarioObterHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioObterRequest, UsuarioObterResponse>
    {
        public async Task<UsuarioObterResponse> Handle(
            UsuarioObterRequest request, CancellationToken cancellationToken)
        {
            var usuario = await repositorioUsuario.ObterUsuarioPorIdAsync(request.Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            var usuarioResponse = new UsuarioObterResponse(
                usuario.Id,
                    usuario.NomeUsuario,
                    usuario.StatusUsuario,

                    usuario.PedidosCadastrados
                        .Select(pedido => new PedidoCadastradoDto(
                            pedido.NumeroPedido,
                            pedido.StatusPedido,
                            pedido.Observacoes
                        )).ToList(),

                    usuario.ProdutosCadastrados
                        .Select(produto => new ProdutoCadastradoDto(
                            produto.NomeProduto
                        )).ToList(),

                    usuario.IngredientesCadastrados
                        .Select(ingrediente => new IngredienteCadastradoDto(
                            ingrediente.NomeIngrediente,
                            ingrediente.QuantidadeEstoque
                        )).ToList(),

                    usuario.ClientesCadastrados
                        .Select(cliente => new ClienteCadastradoDto(
                            cliente.NomeCliente,
                            cliente.DataUltimoPedido,
                            cliente.QuantidadePedidosFeitos,
                            cliente.Observacoes
                        )).ToList()
            );

            return usuarioResponse;
        }
    }
}
