using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnoDoSiriCascudo.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoNomeColunaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadePedido",
                table: "TB_Clientes",
                newName: "QuantidadePedidosFeitos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadePedidosFeitos",
                table: "TB_Clientes",
                newName: "QuantidadePedido");
        }
    }
}
