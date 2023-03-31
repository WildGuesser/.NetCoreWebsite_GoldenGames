using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class SmallUpdateToTableJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Consolas_Id_Categoria",
                table: "Jogos");

            migrationBuilder.AddColumn<int>(
                name: "Id_Consola",
                table: "Jogos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Id_Consola",
                table: "Jogos",
                column: "Id_Consola");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Consolas_Id_Consola",
                table: "Jogos",
                column: "Id_Consola",
                principalTable: "Consolas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Consolas_Id_Consola",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_Id_Consola",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Id_Consola",
                table: "Jogos");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Consolas_Id_Categoria",
                table: "Jogos",
                column: "Id_Categoria",
                principalTable: "Consolas",
                principalColumn: "Id");
        }
    }
}
