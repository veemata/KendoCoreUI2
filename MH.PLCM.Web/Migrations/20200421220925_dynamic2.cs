using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Migrations
{
    public partial class dynamic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErpName",
                table: "DynamicFeatures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErpName",
                table: "DynamicFeatures",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
