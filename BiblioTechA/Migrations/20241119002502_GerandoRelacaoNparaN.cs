using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class GerandoRelacaoNparaN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroPedido_Livros_LivroId",
                table: "LivroPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroPedido_Pedidos_PedidoId",
                table: "LivroPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroPedido",
                table: "LivroPedido");

            migrationBuilder.RenameTable(
                name: "LivroPedido",
                newName: "LivroPedidos");

            migrationBuilder.RenameIndex(
                name: "IX_LivroPedido_PedidoId",
                table: "LivroPedidos",
                newName: "IX_LivroPedidos_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroPedidos",
                table: "LivroPedidos",
                columns: new[] { "LivroId", "PedidoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LivroPedidos_Livros_LivroId",
                table: "LivroPedidos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroPedidos_Pedidos_PedidoId",
                table: "LivroPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroPedidos_Livros_LivroId",
                table: "LivroPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroPedidos_Pedidos_PedidoId",
                table: "LivroPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroPedidos",
                table: "LivroPedidos");

            migrationBuilder.RenameTable(
                name: "LivroPedidos",
                newName: "LivroPedido");

            migrationBuilder.RenameIndex(
                name: "IX_LivroPedidos_PedidoId",
                table: "LivroPedido",
                newName: "IX_LivroPedido_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroPedido",
                table: "LivroPedido",
                columns: new[] { "LivroId", "PedidoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LivroPedido_Livros_LivroId",
                table: "LivroPedido",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroPedido_Pedidos_PedidoId",
                table: "LivroPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
