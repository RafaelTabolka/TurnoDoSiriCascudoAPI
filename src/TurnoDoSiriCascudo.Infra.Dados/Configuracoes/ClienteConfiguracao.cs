using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.ClienteEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCliente)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.DataUltimoPedido)
                .IsRequired(false);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.QuantidadePedidosFeitos)
                .IsRequired();

            builder.Property(c => c.Observacoes)
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(c => c.UsuarioCriadorId)
                .IsRequired();

            builder.Property(c => c.UsuarioAtualizadorId)
                .IsRequired(false);

            builder.ToTable("TB_Clientes");
        }
    }
}
