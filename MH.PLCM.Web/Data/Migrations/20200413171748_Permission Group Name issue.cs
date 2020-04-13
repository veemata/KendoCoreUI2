using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Data.Migrations
{
    public partial class PermissionGroupNameissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "PermissionGroup",
                table: "Permissions",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionGroup",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
