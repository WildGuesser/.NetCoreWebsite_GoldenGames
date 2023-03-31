using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class NothingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Consola_Id_Categoria",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consola",
                table: "Consola");

            migrationBuilder.RenameTable(
                name: "Consola",
                newName: "Consolas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consolas",
                table: "Consolas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Consolas_Id_Categoria",
                table: "Jogos",
                column: "Id_Categoria",
                principalTable: "Consolas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Consolas_Id_Categoria",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consolas",
                table: "Consolas");

            migrationBuilder.RenameTable(
                name: "Consolas",
                newName: "Consola");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consola",
                table: "Consola",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Consola_Id_Categoria",
                table: "Jogos",
                column: "Id_Categoria",
                principalTable: "Consola",
                principalColumn: "Id");
        }
    }
}
