using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Atualizar
{
    internal class UsuarioAtualizarHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioAtualizarRequest, UsuarioAtualizarResponse>
    {
        public async Task<UsuarioAtualizarResponse> Handle(
            UsuarioAtualizarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await repositorioUsuario.ObterPorIdAsync(request.Id);

            if (usuario == null)
                return new UsuarioAtualizarResponse("Usuário não encontrado");

            usuario.Atualizar(request.NomeUsuario);

            repositorioUsuario.Atualizar(usuario);
            await repositorioUsuario.CommitAsync();

            return new UsuarioAtualizarResponse("Usuário atualizado com sucesso");
        }
    }
}
