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

            builder.HasOne(p => p.UsuarioCriador)
                .WithMany(p => p.ProdutosCadastrados)
                .HasForeignKey(p => p.UsuarioCriadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.UsuarioAtualizadorId)
                .IsRequired(false);

            builder.ToTable("TB_Produtos");
        }
    }
}
