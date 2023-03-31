using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class FavCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavCategoriesId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavCategories",
                columns: table => new
                {
                    FavCategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavCategories", x => x.FavCategoriesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_FavCategoriesId",
                table: "Categoria",
                column: "FavCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_FavCategories_FavCategoriesId",
                table: "Categoria",
                column: "FavCategoriesId",
                principalTable: "FavCategories",
                principalColumn: "FavCategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_FavCategories_FavCategoriesId",
                table: "Categoria");

            migrationBuilder.DropTable(
                name: "FavCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_FavCategoriesId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "FavCategoriesId",
                table: "Categoria");
        }
    }
}
