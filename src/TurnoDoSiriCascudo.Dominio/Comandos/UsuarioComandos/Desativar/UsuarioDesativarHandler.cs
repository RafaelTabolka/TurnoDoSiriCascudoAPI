using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Desativar
{
    internal class UsuarioDesativarHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioDesativarRequest, UsuarioDesativarResponse>
    {
        public async Task<UsuarioDesativarResponse> Handle(
            UsuarioDesativarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await repositorioUsuario.ObterPorIdAsync(request.Id);

            if (usuario == null)
                return new UsuarioDesativarResponse("Usuário não encontrado");

            usuario.Desativar();

            repositorioUsuario.Atualizar(usuario);
            await repositorioUsuario.CommitAsync();

            return new UsuarioDesativarResponse("Usuário desativado com sucesso");
        }
    }
}
