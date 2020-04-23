using Microsoft.EntityFrameworkCore.Migrations;

namespace MH.PLCM.Migrations
{
    public partial class dynamictables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicFeatures",
                columns: table => new
                {
                    RowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DataTypeID = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    LookupID = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    ReportGroupID = table.Column<int>(nullable: false),
                    GroupOrder = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    UnitOfMeasure = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    IsBaanFeature = table.Column<bool>(nullable: false),
                    ResponsibleGroupID = table.Column<int>(nullable: false, comment: "Lookup 1041"),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    ErpName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFeatures", x => x.RowID);
                });

            migrationBuilder.CreateTable(
                name: "DynamicItems",
                columns: table => new
                {
                    RowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityTypeId = table.Column<int>(nullable: false),
                    EntityKeyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicItem", x => x.RowID);
                });

            migrationBuilder.CreateTable(
                name: "DynamicTemplates",
                columns: table => new
                {
                    RowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.RowID);
                });

            migrationBuilder.CreateTable(
                name: "DynamicItemFeatures",
                columns: table => new
                {
                    RowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemRowID = table.Column<int>(nullable: false),
                    FeatureRowID = table.Column<int>(nullable: false),
                    FeatureValue = table.Column<string>(unicode: false, maxLength: 1000, nullable: false),
                    Comments = table.Column<string>(unicode: false, maxLength: 100, nullable: false, defaultValueSql: "('')"),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicPackaging", x => x.RowID);
                    table.ForeignKey(
                        name: "FK_DynamicPackaging_DynamicFeatures",
                        column: x => x.FeatureRowID,
                        principalTable: "DynamicFeatures",
                        principalColumn: "RowID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DynamicPackaging_DynamicItem",
                        column: x => x.ItemRowID,
                        principalTable: "DynamicItems",
                        principalColumn: "RowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DynamicTemplateFeatures",
                columns: table => new
                {
                    RowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateRowID = table.Column<int>(nullable: false),
                    FeatureRowID = table.Column<int>(nullable: false),
                    FeatureValue = table.Column<string>(unicode: false, maxLength: 1000, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTemplateFeatures", x => x.RowID);
                    table.ForeignKey(
                        name: "FK_DynamicTemplateFeatures_DynamicTemplates",
                        column: x => x.TemplateRowID,
                        principalTable: "DynamicTemplates",
                        principalColumn: "RowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicItemFeatures_FeatureRowID",
                table: "DynamicItemFeatures",
                column: "FeatureRowID");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicItemFeatures",
                table: "DynamicItemFeatures",
                columns: new[] { "ItemRowID", "FeatureRowID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTemplateFeatures",
                table: "DynamicTemplateFeatures",
                columns: new[] { "TemplateRowID", "FeatureRowID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTemplates",
                table: "DynamicTemplates",
                column: "TemplateName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicItemFeatures");

            migrationBuilder.DropTable(
                name: "DynamicTemplateFeatures");

            migrationBuilder.DropTable(
                name: "DynamicFeatures");

            migrationBuilder.DropTable(
                name: "DynamicItems");

            migrationBuilder.DropTable(
                name: "DynamicTemplates");
        }
    }
}
