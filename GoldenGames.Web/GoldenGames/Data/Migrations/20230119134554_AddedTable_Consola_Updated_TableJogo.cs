using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class AddedTable_Consola_Updated_TableJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consola",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consola", x => x.Id);
                });



            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Consola_Id_Categoria",
                table: "Jogos",
                column: "Id_Categoria",
                principalTable: "Consola",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Consola_Id_Categoria",
                table: "Jogos");

            migrationBuilder.DropTable(
                name: "Consola");

        }
    }
}
