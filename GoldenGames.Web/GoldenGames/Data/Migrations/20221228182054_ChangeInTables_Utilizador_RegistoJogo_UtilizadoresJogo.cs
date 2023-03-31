using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class ChangeInTables_Utilizador_RegistoJogo_UtilizadoresJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "_Utilizadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Utilizadores",
                table: "_Utilizadores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Categoria = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Produtora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jogos_Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Jogo = table.Column<int>(type: "int", nullable: true),
                    Id_Compra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Compra_Compra_Id_Compra",
                        column: x => x.Id_Compra,
                        principalTable: "Compra",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jogos_Compra_Jogos_Id_Jogo",
                        column: x => x.Id_Jogo,
                        principalTable: "Jogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistoJogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Utilizador = table.Column<int>(type: "int", nullable: true),
                    Id_Jogo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistoJogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistoJogo_Jogos_Id_Jogo",
                        column: x => x.Id_Jogo,
                        principalTable: "Jogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores_Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Utilizador = table.Column<int>(type: "int", nullable: true),
                    Id_Jogos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Jogos_Jogos_Id_Jogos",
                        column: x => x.Id_Jogos,
                        principalTable: "Jogos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Id_Categoria",
                table: "Jogos",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Compra_Id_Compra",
                table: "Jogos_Compra",
                column: "Id_Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Compra_Id_Jogo",
                table: "Jogos_Compra",
                column: "Id_Jogo");

            migrationBuilder.CreateIndex(
                name: "IX_RegistoJogo_Id_Jogo",
                table: "RegistoJogo",
                column: "Id_Jogo");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_Jogos_Id_Jogos",
                table: "Utilizadores_Jogos",
                column: "Id_Jogos");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims__Utilizadores_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins__Utilizadores_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles__Utilizadores_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens__Utilizadores_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims__Utilizadores_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins__Utilizadores_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles__Utilizadores_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens__Utilizadores_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Jogos_Compra");

            migrationBuilder.DropTable(
                name: "RegistoJogo");

            migrationBuilder.DropTable(
                name: "Utilizadores_Jogos");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Utilizadores",
                table: "_Utilizadores");

            migrationBuilder.RenameTable(
                name: "_Utilizadores",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
