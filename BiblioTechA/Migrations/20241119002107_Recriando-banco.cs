using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class Recriandobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Biblioteca_BiblioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_BiblioId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "BiblioId",
                table: "Livros");

            migrationBuilder.CreateTable(
                name: "Acervo",
                columns: table => new
                {
                    BiblioId = table.Column<int>(type: "int", nullable: false),
                    LivroAcervoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acervo", x => new { x.LivroAcervoId, x.BiblioId });
                    table.ForeignKey(
                        name: "FK_Acervo_Biblioteca_BiblioId",
                        column: x => x.BiblioId,
                        principalTable: "Biblioteca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acervo_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acervo_BiblioId",
                table: "Acervo",
                column: "BiblioId");

            migrationBuilder.CreateIndex(
                name: "IX_Acervo_LivroId",
                table: "Acervo",
                column: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acervo");

            migrationBuilder.AddColumn<int>(
                name: "BiblioId",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_BiblioId",
                table: "Livros",
                column: "BiblioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Biblioteca_BiblioId",
                table: "Livros",
                column: "BiblioId",
                principalTable: "Biblioteca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
