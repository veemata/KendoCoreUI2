using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Data.Migrations
{
    public partial class PermissionParentChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionGroup",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionParentId",
                table: "Permissions",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionParentId",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "PermissionGroup",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
