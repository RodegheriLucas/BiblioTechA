using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class LivroPedidosPedidoLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Leitores_LeitorId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Livros_LivroId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_LivroId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Livros_LeitorId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LeitorId",
                table: "Livros");

            migrationBuilder.CreateTable(
                name: "LivroPedido",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroPedido", x => new { x.LivroId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_LivroPedido_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroPedido_PedidoId",
                table: "LivroPedido",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroPedido");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeitorId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LivroId",
                table: "Pedidos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LeitorId",
                table: "Livros",
                column: "LeitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Leitores_LeitorId",
                table: "Livros",
                column: "LeitorId",
                principalTable: "Leitores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Livros_LivroId",
                table: "Pedidos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
