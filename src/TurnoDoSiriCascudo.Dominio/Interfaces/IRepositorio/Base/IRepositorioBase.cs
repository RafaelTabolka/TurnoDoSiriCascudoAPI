using TurnoDoSiriCascudo.Dominio.Entidades.Base;

namespace TurnoDoSiriCascudo.Dominio.Interfaces.IRepositorio.Base
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task AdicionarAsync(TEntity entidade);
        void Atualizar(TEntity entidade);
        Task DeletarAsync(Guid id);
        Task CommitAsync();
    }
}
