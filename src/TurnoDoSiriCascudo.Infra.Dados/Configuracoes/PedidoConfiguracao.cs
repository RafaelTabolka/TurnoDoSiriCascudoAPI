using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.PedidoEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.Property(p => p.StatusPedido)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(p => p.Observacoes)
                .IsRequired(false)
                .HasMaxLength(300);

            builder.HasOne(p => p.UsuarioCriador)
                .WithMany(p => p.PedidosCadastrados)
                .HasForeignKey(p => p.UsuarioCriadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(p => p.UsuarioAtualizadorId)
                .IsRequired(false);

            builder.ToTable("TB_Pedidos");
        }
    }
}
