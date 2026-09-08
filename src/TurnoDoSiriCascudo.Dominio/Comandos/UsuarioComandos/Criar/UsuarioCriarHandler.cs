using MediatR;
using Microsoft.AspNetCore.Identity;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;
using TurnoDoSiriCascudo.Dominio.Interfaces.IServicoToken;

namespace TurnoDoSiriCascudo.Dominio.Comandos.UsuarioComandos.Criar
{
    internal class UsuarioCriarHandler(
        IRepositorioUsuario repositorioUsuario,
        IPasswordHasher<Usuario> senhaHasher,
        IServicoToken servicoToken) :
        IRequestHandler<UsuarioCriarRequest, UsuarioCriarResponse>
    {
        public async Task<UsuarioCriarResponse> Handle(
            UsuarioCriarRequest request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.NomeUsuario);

            var senhaHash = senhaHasher.HashPassword(
                usuario,
                request.Senha
            );

            usuario.DefineSenhaHash(senhaHash);

            var token = servicoToken.GerarToken(usuario);

            await repositorioUsuario.AdicionarAsync(usuario);
            await repositorioUsuario.CommitAsync();

            return new UsuarioCriarResponse(usuario.Id, token);
        }
    }
}
