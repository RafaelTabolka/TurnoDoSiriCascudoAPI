using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Listar
{
    internal class UsuarioListarHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioListarRequest, List<UsuarioListarResponse>>
    {
        public async Task<List<UsuarioListarResponse>> Handle(
            UsuarioListarRequest request, CancellationToken cancellationToken)
        {
            var usuarios = await repositorioUsuario.ObterTodosOsUsuariosAsync();

            var usuariosReponse = usuarios
                .Select(usuario => new UsuarioListarResponse(
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
                )).ToList();

            return usuariosReponse;
        }
    }
}
