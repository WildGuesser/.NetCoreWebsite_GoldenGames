using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class UpdateTables_RJogo_Utili_UJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id_Utilizador",
                table: "Utilizadores_Jogos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPerfil",
                table: "Utilizadores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id_Utilizador",
                table: "RegistoJogo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_Jogos_Id_Utilizador",
                table: "Utilizadores_Jogos",
                column: "Id_Utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_RegistoJogo_Id_Utilizador",
                table: "RegistoJogo",
                column: "Id_Utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistoJogo_Utilizadores_Id_Utilizador",
                table: "RegistoJogo",
                column: "Id_Utilizador",
                principalTable: "Utilizadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizadores_Jogos_Utilizadores_Id_Utilizador",
                table: "Utilizadores_Jogos",
                column: "Id_Utilizador",
                principalTable: "Utilizadores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistoJogo_Utilizadores_Id_Utilizador",
                table: "RegistoJogo");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizadores_Jogos_Utilizadores_Id_Utilizador",
                table: "Utilizadores_Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Utilizadores_Jogos_Id_Utilizador",
                table: "Utilizadores_Jogos");

            migrationBuilder.DropIndex(
                name: "IX_RegistoJogo_Id_Utilizador",
                table: "RegistoJogo");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Utilizadores");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Utilizador",
                table: "Utilizadores_Jogos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Utilizador",
                table: "RegistoJogo",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
