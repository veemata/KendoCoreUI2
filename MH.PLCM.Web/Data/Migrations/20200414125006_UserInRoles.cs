using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Data.Migrations
{
    public partial class UserInRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRoles_ApplicationRoleId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole");

            migrationBuilder.RenameTable(
                name: "ApplicationUserRole",
                newName: "UserApplicationRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_ApplicationUserId",
                table: "UserApplicationRoles",
                newName: "IX_UserApplicationRoles_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_ApplicationRoleId",
                table: "UserApplicationRoles",
                newName: "IX_UserApplicationRoles_ApplicationRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserApplicationRoles",
                table: "UserApplicationRoles",
                columns: new[] { "UserId", "ApplicationRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplicationRoles_ApplicationRoles_ApplicationRoleId",
                table: "UserApplicationRoles",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRoles",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplicationRoles_AspNetUsers_ApplicationUserId",
                table: "UserApplicationRoles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApplicationRoles_ApplicationRoles_ApplicationRoleId",
                table: "UserApplicationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApplicationRoles_AspNetUsers_ApplicationUserId",
                table: "UserApplicationRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserApplicationRoles",
                table: "UserApplicationRoles");

            migrationBuilder.RenameTable(
                name: "UserApplicationRoles",
                newName: "ApplicationUserRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserApplicationRoles_ApplicationUserId",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserApplicationRoles_ApplicationRoleId",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_ApplicationRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole",
                columns: new[] { "UserId", "ApplicationRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRoles_ApplicationRoleId",
                table: "ApplicationUserRole",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRoles",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserRole",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
