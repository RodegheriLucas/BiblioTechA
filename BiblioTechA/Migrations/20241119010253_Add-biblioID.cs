using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTechA.Migrations
{
    /// <inheritdoc />
    public partial class AddbiblioID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BiblioId",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiblioId",
                table: "Livros");
        }
    }
}
