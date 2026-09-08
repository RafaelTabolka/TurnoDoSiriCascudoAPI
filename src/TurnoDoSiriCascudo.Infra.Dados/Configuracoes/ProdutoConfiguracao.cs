using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeProduto)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.UsuarioCriadorId)
                .IsRequired();

            builder.Property(p => p.UsuarioAtualizadorId)
                .IsRequired(false);

            builder.ToTable("TB_Produtos");
        }
    }
}
