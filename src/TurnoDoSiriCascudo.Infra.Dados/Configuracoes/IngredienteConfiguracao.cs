using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.IngredienteEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class IngredienteConfiguracao : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.UsuarioCriadorId)
                .IsRequired();

            builder.Property(i => i.UsuarioAtualizadorId)
                .IsRequired(false);

            builder.Property(i => i.QuantidadeEstoque)
                .IsRequired();

            builder.ToTable("TB_Ingredientes");
        }
    }
}
