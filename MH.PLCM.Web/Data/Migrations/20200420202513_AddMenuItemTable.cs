using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Data.Migrations
{
    public partial class AddMenuItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuText = table.Column<string>(maxLength: 50, nullable: true),
                    LinkUrl = table.Column<string>(maxLength: 255, nullable: true),
                    CssClassForIcon = table.Column<string>(nullable: true),
                    MenuOrder = table.Column<int>(nullable: false),
                    ParentMenuItemId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuItemId",
                table: "Menus",
                column: "MenuItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
