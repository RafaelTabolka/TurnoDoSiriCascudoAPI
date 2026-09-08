using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurnoDoSiriCascudo.Dominio.Entidades.ProdutoPedidoEntidade;

namespace TurnoDoSiriCascudo.Infra.Dados.Configuracoes
{
    internal class ProdutoPedidoConfiguracao : IEntityTypeConfiguration<ProdutoPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            builder.HasKey(p => new
            {
                p.ProdutoId,
                p.PedidoId
            });

            builder.Property(p => p.QuantidadeProduto)
                .IsRequired();

            builder.ToTable("TB_ProdutosPedidos");
        }
    }
}
