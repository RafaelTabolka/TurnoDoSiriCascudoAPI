using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteProdutoEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class IngredienteProdutoConfiguracao : IEntityTypeConfiguration<IngredienteProduto>
    {
        public void Configure(EntityTypeBuilder<IngredienteProduto> builder)
        {
            builder.HasKey(i => new
            {
                i.ProdutoId,
                i.IngredienteId
            });

            builder.Property(i => i.QuantidadeIngrediente)
                .IsRequired();

            builder.ToTable("TB_IngredientesProdutos");
        }
    }
}
