using MediatR;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.PapelAdmin
{
    internal class UsuarioPapelAdminHandler(IRepositorioUsuario repositorioUsuario) :
        IRequestHandler<UsuarioPapelAdminRequest, UsuarioPapelAdminResponse>
    {
        public async Task<UsuarioPapelAdminResponse> Handle(
            UsuarioPapelAdminRequest request, CancellationToken cancellationToken)
        {
            var usuario = await repositorioUsuario.ObterPorIdAsync(request.Id);

            if (usuario == null)
                return new UsuarioPapelAdminResponse("Usuário não encontrado");

            usuario.TornarAdmin();

            repositorioUsuario.Atualizar(usuario);
            await repositorioUsuario.CommitAsync();

            return new UsuarioPapelAdminResponse("Usuário agora tem status administrador");
        }
    }
}
