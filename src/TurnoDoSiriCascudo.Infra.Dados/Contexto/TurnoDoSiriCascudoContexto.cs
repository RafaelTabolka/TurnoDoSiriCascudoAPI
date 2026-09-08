using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using TurnoDoSiriCascudo.Dominio.Entidades.Base;
using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoPedidoEntidade;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;
using TurnoDoSiriCascudo.Infra.CrossCutting.Extensoes.Extensoes;

namespace TurnoDoSiriCascudo.Infra.Dados.Contexto
{
    public class TurnoDoSiriCascudoContexto(DbContextOptions<TurnoDoSiriCascudoContexto> opcoes) : DbContext(opcoes)
    {
        public DbSet<Cliente> ClienteSet { get; set; }
        public DbSet<Ingrediente> IngredienteSet { get; set; }
        public DbSet<IngredienteProduto> IngredienteProdutoSet { get; set; }
        public DbSet<Pedido> PedidoSet { get; set; }
        public DbSet<Produto> ProdutoSet { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedidoSet { get; set; }
        public DbSet<Usuario> UsuarioSet { get; set; }

        // Aplica automaticamente as configurações das entidades ao criar o modelo do banco.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        // Preenche automaticamente as datas de criação e edição antes de salvar as alterações no banco.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DefinirInformacoesDeCriacao();
            DefinirInformacoesDeAtualizacao();
            return base.SaveChangesAsync(cancellationToken);
        }

        // Retorna as entidades rastreadas pelo Entity Framework que possuem o tipo e o estado informados.
        private IEnumerable<TEntityBase> ObterEntidadesRastreadasPorEstado<TEntityBase>(
            EntityState estadoEntidade)
        {
            // Esse trecho procura, entre todas as entidades rastreadas pelo Entity Framework,
            // aquelas que possuem o tipo e o estado solicitados.

            /*
            ChangeTracker.Entries()
            Retorna todos os registros que o Entity Framework está rastreando naquele momento.
            Cada registro contém principalmente:
            e.Entity: a entidade propriamente dita;
            e.State: o estado da entidade, como Added, Modified ou Deleted.

            from e in ChangeTracker.Entries()
            Percorre cada registro rastreado. A letra "e" representa um registro por vez.
            "e" não é diretamente a entidade. Ele é um registro de rastreamento 
            que contém a entidade e seu estado.

            where e.Entity is TEntityBase
            Verifica se a entidade pertence ao tipo solicitado.
            Assim, somente entidades que herdam de EntidadeBase serão selecionadas.

            && e.State == estadoEntidade
            Verifica se a entidade possui o estado solicitado.
            Por exemplo, se foi informado: EntityState.Added

            select (TEntityBase)e.Entity;
            Seleciona a entidade encontrada e converte seu tipo para TEntityBase.
             */
            return from e in ChangeTracker.Entries()
                   where e.Entity is TEntityBase && e.State == estadoEntidade
                   select (TEntityBase)e.Entity;
        }

        // Define a data de criação das entidades que estão sendo adicionadas ao banco.
        protected virtual void DefinirInformacoesDeCriacao()
        {
            ObterEntidadesRastreadasPorEstado<EntidadeBase>(EntityState.Added)
                .ForEach(entidade => entidade.CriadoEm = DateTime.UtcNow);
        }

        // Define a data de edição das entidades que estão sendo alteradas no banco.
        protected virtual void DefinirInformacoesDeAtualizacao()
        {
            ObterEntidadesRastreadasPorEstado<EntidadeBase>(EntityState.Modified)
                .ForEach(entidade => entidade.EditadoEm = DateTime.UtcNow);
        }
    }
}
