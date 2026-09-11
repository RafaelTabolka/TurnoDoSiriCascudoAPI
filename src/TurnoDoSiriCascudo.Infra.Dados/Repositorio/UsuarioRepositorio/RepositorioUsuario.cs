using Microsoft.EntityFrameworkCore;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.UsuarioRepositorio;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;
using TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.UsuarioRepositorio
{
    public class RepositorioUsuario(TurnoDoSiriCascudoContexto contexto) :
        RepositorioBase<Usuario>(contexto), IRepositorioUsuario
    {
        public async Task<List<Usuario>> ObterTodosOsUsuariosAsync()
        {
            return await DbSet
                .Include(usuario => usuario.PedidosCadastrados)
                .Include(usuario => usuario.ProdutosCadastrados)
                .Include(usuario => usuario.IngredientesCadastrados)
                .Include(usuario => usuario.ClientesCadastrados)
                .ToListAsync();
        }

        public async Task<Usuario?> ObterUsuarioPorIdAsync(Guid id)
        {
            return await DbSet
                .Include(usuario => usuario.PedidosCadastrados)
                .Include(usuario => usuario.ProdutosCadastrados)
                .Include(usuario => usuario.IngredientesCadastrados)
                .Include(usuario => usuario.ClientesCadastrados)
                .FirstOrDefaultAsync(usuario => usuario.Id == id);
        }
    }
}
