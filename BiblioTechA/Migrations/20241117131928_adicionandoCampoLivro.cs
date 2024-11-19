using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoCampoLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Livros_LivroId",
                table: "Biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_Biblioteca_LivroId",
                table: "Biblioteca");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Biblioteca");

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
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Biblioteca_BiblioId",
                table: "Livros",
                column: "BiblioId",
                principalTable: "Biblioteca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Biblioteca",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_LivroId",
                table: "Biblioteca",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Livros_LivroId",
                table: "Biblioteca",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id");
        }
    }
}
