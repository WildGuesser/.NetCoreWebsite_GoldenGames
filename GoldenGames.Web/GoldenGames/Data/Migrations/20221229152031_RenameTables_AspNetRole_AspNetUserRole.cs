using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenGames.Data.Migrations
{
    public partial class RenameTables_AspNetRole_AspNetUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

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
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens__Utilizadores_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Utilizadores",
                table: "_Utilizadores");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "Utilizador_Role_Utilizadores");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role_Utilizadores");

            migrationBuilder.RenameTable(
                name: "_Utilizadores",
                newName: "Utilizadores");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "Utilizador_Role_Utilizadores",
                newName: "IX_Utilizador_Role_Utilizadores_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizador_Role_Utilizadores",
                table: "Utilizador_Role_Utilizadores",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role_Utilizadores",
                table: "Role_Utilizadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Role_Utilizadores_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Role_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Utilizadores_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Utilizadores_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Utilizadores_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizador_Role_Utilizadores_Role_Utilizadores_RoleId",
                table: "Utilizador_Role_Utilizadores",
                column: "RoleId",
                principalTable: "Role_Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizador_Role_Utilizadores_Utilizadores_UserId",
                table: "Utilizador_Role_Utilizadores",
                column: "UserId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Role_Utilizadores_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Utilizadores_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Utilizadores_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Utilizadores_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizador_Role_Utilizadores_Role_Utilizadores_RoleId",
                table: "Utilizador_Role_Utilizadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizador_Role_Utilizadores_Utilizadores_UserId",
                table: "Utilizador_Role_Utilizadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizador_Role_Utilizadores",
                table: "Utilizador_Role_Utilizadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_Utilizadores",
                table: "Role_Utilizadores");

            migrationBuilder.RenameTable(
                name: "Utilizadores",
                newName: "_Utilizadores");

            migrationBuilder.RenameTable(
                name: "Utilizador_Role_Utilizadores",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Role_Utilizadores",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_Utilizador_Role_Utilizadores_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Utilizadores",
                table: "_Utilizadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
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
    }
}
