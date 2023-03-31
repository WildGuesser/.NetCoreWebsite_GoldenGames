using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class SmallUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_FavCategories_FavCategoriesId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_FavCategoriesId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "FavCategoriesId",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FavCategories",
                newName: "Id_User");

            migrationBuilder.AlterColumn<string>(
                name: "Id_User",
                table: "FavCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id_Categoria",
                table: "FavCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FavCategories_Id_Categoria",
                table: "FavCategories",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_FavCategories_Id_User",
                table: "FavCategories",
                column: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_FavCategories_Categoria_Id_Categoria",
                table: "FavCategories",
                column: "Id_Categoria",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavCategories_Utilizadores_Id_User",
                table: "FavCategories",
                column: "Id_User",
                principalTable: "Utilizadores",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_FavCategories_Categoria_Id_Categoria",
                table: "FavCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FavCategories_Utilizadores_Id_User",
                table: "FavCategories");

            migrationBuilder.DropIndex(
                name: "IX_FavCategories_Id_Categoria",
                table: "FavCategories");

            migrationBuilder.DropIndex(
                name: "IX_FavCategories_Id_User",
                table: "FavCategories");

            migrationBuilder.DropColumn(
                name: "Id_Categoria",
                table: "FavCategories");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "FavCategories",
                newName: "UserId");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPerfil",
                table: "Utilizadores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavCategoriesId",
                table: "Categoria",
                type: "int",
                nullable: true);

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
    }
}
