using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnoDoSiriCascudo.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusUsuario = table.Column<string>(type: "varchar(10)", nullable: false),
                    PapelUsuario = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataUltimoPedido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    QuantidadePedido = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UsuarioCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Clientes_TB_Usuarios_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Ingredientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Ingredientes_TB_Usuarios_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UsuarioCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Produtos_TB_Usuarios_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroPedido = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusPedido = table.Column<string>(type: "varchar(15)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UsuarioCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAtualizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Pedidos_TB_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Pedidos_TB_Usuarios_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_IngredientesProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeIngrediente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IngredientesProdutos", x => new { x.ProdutoId, x.IngredienteId });
                    table.ForeignKey(
                        name: "FK_TB_IngredientesProdutos_TB_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "TB_Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_IngredientesProdutos_TB_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "TB_Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ProdutosPedidos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ProdutosPedidos", x => new { x.ProdutoId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_TB_ProdutosPedidos_TB_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "TB_Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ProdutosPedidos_TB_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "TB_Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Clientes_UsuarioCriadorId",
                table: "TB_Clientes",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Ingredientes_UsuarioCriadorId",
                table: "TB_Ingredientes",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IngredientesProdutos_IngredienteId",
                table: "TB_IngredientesProdutos",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Pedidos_ClienteId",
                table: "TB_Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Pedidos_UsuarioCriadorId",
                table: "TB_Pedidos",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Produtos_UsuarioCriadorId",
                table: "TB_Produtos",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ProdutosPedidos_PedidoId",
                table: "TB_ProdutosPedidos",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_IngredientesProdutos");

            migrationBuilder.DropTable(
                name: "TB_ProdutosPedidos");

            migrationBuilder.DropTable(
                name: "TB_Ingredientes");

            migrationBuilder.DropTable(
                name: "TB_Pedidos");

            migrationBuilder.DropTable(
                name: "TB_Produtos");

            migrationBuilder.DropTable(
                name: "TB_Clientes");

            migrationBuilder.DropTable(
                name: "TB_Usuarios");
        }
    }
}
