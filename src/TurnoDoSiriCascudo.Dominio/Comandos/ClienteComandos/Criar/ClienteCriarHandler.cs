using MediatR;
using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.ClienteRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.ClienteComandos.Criar
{
    internal class ClienteCriarHandler(IRepositorioCliente repositorioCliente) :
        IRequestHandler<ClienteCriarRequest, ClienteCriarResponse>
    {
        public async Task<ClienteCriarResponse> Handle(
            ClienteCriarRequest request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(
                request.NomeCliente,
                request.Telefone,
                request.Observacoes,
                request.UsuarioCriadorId
            );

            await repositorioCliente.AdicionarAsync(cliente);
            await repositorioCliente.CommitAsync();

            return new ClienteCriarResponse(cliente.Id, "Cliente criado com sucesso");
        }
    }
}
