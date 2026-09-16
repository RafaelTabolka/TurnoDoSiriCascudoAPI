using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Ativar
{
    internal class UsuarioAtivarHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioAtivarRequest, UsuarioAtivarResponse>
    {
        public async Task<UsuarioAtivarResponse> Handle(
            UsuarioAtivarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await repositorioUsuario.ObterPorIdAsync(request.Id);

            if (usuario == null)
                return new UsuarioAtivarResponse("Usuário não encontrado");

            usuario.Ativar();

            repositorioUsuario.Atualizar(usuario);
            await repositorioUsuario.CommitAsync();

            return new UsuarioAtivarResponse("Usuário ativado com sucesso");
        }
    }
}
