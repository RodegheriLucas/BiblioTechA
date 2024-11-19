using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class iniciando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Leitores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiblioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeitorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biblioteca_Leitores_LeitorId",
                        column: x => x.LeitorId,
                        principalTable: "Leitores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeitorCpf = table.Column<int>(type: "int", nullable: true),
                    LeitorId = table.Column<int>(type: "int", nullable: true),
                    BiblioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Biblioteca_BiblioId",
                        column: x => x.BiblioId,
                        principalTable: "Biblioteca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Leitores_LeitorId",
                        column: x => x.LeitorId,
                        principalTable: "Leitores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_LeitorId",
                table: "Biblioteca",
                column: "LeitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_BiblioId",
                table: "Livros",
                column: "BiblioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LeitorId",
                table: "Livros",
                column: "LeitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Biblioteca");

            migrationBuilder.DropTable(
                name: "Leitores");
        }
    }
}
