using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class ChangeTables_Compra_Jogo_Utilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Compra");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Jogos",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total_Preco",
                table: "Compra",
                type: "decimal(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Compra",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Compra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UserId",
                table: "Compra",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Utilizadores_UserId",
                table: "Compra",
                column: "UserId",
                principalTable: "Utilizadores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Utilizadores_UserId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UserId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "Total_Preco",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Compra");

            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "Jogos",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Compra",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
