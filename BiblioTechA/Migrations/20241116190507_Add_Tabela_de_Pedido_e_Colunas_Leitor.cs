using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tabela_de_Pedido_e_Colunas_Leitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeitorCpf",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "Cpf",
                table: "Leitores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "Leitores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devolve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LivroNomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Leitores_LeitorId",
                        column: x => x.LeitorId,
                        principalTable: "Leitores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Livros_LivroNomeId",
                        column: x => x.LivroNomeId,
                        principalTable: "Livros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LeitorId",
                table: "Pedidos",
                column: "LeitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LivroNomeId",
                table: "Pedidos",
                column: "LivroNomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Leitores");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Leitores");

            migrationBuilder.AddColumn<int>(
                name: "LeitorCpf",
                table: "Livros",
                type: "int",
                nullable: true);
        }
    }
}
