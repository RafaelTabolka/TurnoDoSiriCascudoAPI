using Microsoft.EntityFrameworkCore;
using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.Base;
using TurnoDoSiriCascudo.Infra.Dados.Contexto;

namespace TurnoDoSiriCascudo.Infra.Dados.Repositorio.Base
{
    public class RepositorioBase<TEntity>(TurnoDoSiriCascudoContexto contexto) :
        IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly DbSet<TEntity> DbSet = contexto.Set<TEntity>();

        public async Task AdicionarAsync(TEntity entidade)
        {
            await DbSet.AddAsync(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
        }

        public async Task CommitAsync()
        {
            await contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var entidade = await DbSet.FindAsync(id);

            if (entidade is not null)
                DbSet.Remove(entidade);
        }

        public async Task<TEntity?> ObterPorIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
