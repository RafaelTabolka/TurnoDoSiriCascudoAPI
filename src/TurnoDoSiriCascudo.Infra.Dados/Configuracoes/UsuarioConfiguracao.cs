using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.UsuarioEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.NomeUsuario)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.StatusUsuario)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("TB_Usuarios");
        }
    }
}
