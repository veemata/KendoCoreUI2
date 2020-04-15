using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MH.PLCM.Data.Migrations
{
    public partial class UserToApplicationMMRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NACO_EngArtworkRequestPlate");

            migrationBuilder.DropTable(
                name: "NACO_Engineering");

            migrationBuilder.DropTable(
                name: "NACO_Filter");

            migrationBuilder.DropTable(
                name: "NACO_History");

            migrationBuilder.DropTable(
                name: "NACO_MSS");

            migrationBuilder.DropTable(
                name: "NACO_NewPart");

            migrationBuilder.DropTable(
                name: "NACO_Packaging");

            migrationBuilder.DropTable(
                name: "NACO_PackagingValImages");

            migrationBuilder.DropTable(
                name: "NACO_Quality");

            migrationBuilder.DropTable(
                name: "NACO_Trigger");

            migrationBuilder.DropTable(
                name: "NACO_Validations");

            migrationBuilder.DropTable(
                name: "NACO_EngArtworkRequest");

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ApplicationRoleId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => new { x.UserId, x.ApplicationRoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ApplicationRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_ApplicationRoleId",
                table: "ApplicationUserRole",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_ApplicationUserId",
                table: "ApplicationUserRole",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.CreateTable(
                name: "NACO_EngArtworkRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtWorkOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    BackPanel = table.Column<int>(type: "int", nullable: true),
                    CautionStatement = table.Column<int>(type: "int", nullable: true),
                    DoubleseamLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FilterTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsNewPart = table.Column<int>(type: "int", nullable: true),
                    IsUlListing = table.Column<int>(type: "int", nullable: true),
                    NumOfTurns = table.Column<int>(type: "int", nullable: true),
                    Panel1 = table.Column<int>(type: "int", nullable: true),
                    Panel2 = table.Column<int>(type: "int", nullable: true),
                    Panel3 = table.Column<int>(type: "int", nullable: true),
                    Panel4 = table.Column<int>(type: "int", nullable: true),
                    PanelCenterLine = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PlateOrientation = table.Column<int>(type: "int", nullable: true),
                    RequestorId = table.Column<int>(type: "int", nullable: true),
                    RunOnLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecialInstructions = table.Column<string>(type: "ntext", nullable: true),
                    Style = table.Column<int>(type: "int", nullable: true),
                    TorqueNumbers = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_EngArtworkRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Engineering",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CustomerSafetyStock = table.Column<double>(type: "float", nullable: false),
                    DeptCodeId = table.Column<long>(type: "bigint", nullable: true),
                    DesignValidationLevel = table.Column<int>(type: "int", nullable: true),
                    DesignerId = table.Column<long>(type: "bigint", nullable: true),
                    EngineerId = table.Column<long>(type: "bigint", nullable: true),
                    FirstShipId = table.Column<long>(type: "bigint", nullable: false),
                    IsPPAPRequired = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    IsPurchasedProduct = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    IsSupPPAPRequired = table.Column<byte>(type: "tinyint", nullable: false),
                    IsUlListing = table.Column<int>(type: "int", nullable: true),
                    ManufacturerPartNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PackagingFilterTypeId = table.Column<long>(type: "bigint", nullable: true),
                    PPAPDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PPAPLevelId = table.Column<long>(type: "bigint", nullable: true),
                    PPAPQty = table.Column<int>(type: "int", nullable: true),
                    PurchasedEleSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualityContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualityContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierPartNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToolingPaidBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalToolingCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Engineering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Filter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementHeight = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ElementIdentinfication = table.Column<int>(type: "int", nullable: true),
                    ElementLength = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ElementThread = table.Column<int>(type: "int", nullable: true),
                    ElementWidth = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FilterWeight = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Identification = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    IDMethodId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('None')"),
                    Inkcolor1 = table.Column<int>(type: "int", nullable: true),
                    Inkcolor2 = table.Column<int>(type: "int", nullable: true),
                    InkpartNumber1 = table.Column<int>(type: "int", nullable: true),
                    InkpartNumber2 = table.Column<int>(type: "int", nullable: true),
                    InnerDiameterBottom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    InnerDiameterLabelPartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    InnerDiameterTop = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MasterPlatePartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    Other = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OuterDiameterBottom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OuterDiameterTop = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PaintColorId = table.Column<long>(type: "bigint", nullable: true),
                    PaintPartNumber = table.Column<int>(type: "int", nullable: true),
                    PaintPlateIdentification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlateOrientation = table.Column<int>(type: "int", nullable: true),
                    PrintPlate1PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    PrintPlate2PartNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Filter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_History",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ChangeOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangingUserId = table.Column<int>(type: "int", nullable: true),
                    Filename = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_MSS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualEOQ = table.Column<int>(type: "int", nullable: true),
                    ActualInitialRun = table.Column<int>(type: "int", nullable: true),
                    ActualStandardCost = table.Column<float>(type: "real", nullable: true),
                    BillOfLadingId = table.Column<long>(type: "bigint", nullable: true),
                    NOQMOQ = table.Column<int>(type: "int", nullable: true),
                    OrderIntervalId = table.Column<long>(type: "bigint", nullable: true),
                    PlannerId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduledOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    SelectionCodeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_MSS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_NewPart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Complete = table.Column<bool>(type: "bit", nullable: true),
                    DrawingFile = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    ItemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NPrev = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    NPsheet = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    PartNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PpapLevel = table.Column<int>(type: "int", nullable: true),
                    PpapQty = table.Column<int>(type: "int", nullable: true),
                    PrintComplete = table.Column<bool>(type: "bit", nullable: true),
                    PrintCompletedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrintReleased = table.Column<bool>(type: "bit", nullable: true),
                    PrintReleasedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductCode = table.Column<bool>(type: "bit", nullable: true),
                    PurchaseMenu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToolingCost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToolingDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToolingOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToolingOrdered = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_NewPart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Packaging",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCodeId = table.Column<long>(type: "bigint", nullable: true),
                    BoxCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxGraphics = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxPrint = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BoxSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonGraphics = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonLabelQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonOther = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartonStenmark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCodeSpec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    I2of5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsRoundFullCarton = table.Column<int>(type: "int", nullable: true),
                    IsUpcPrefix = table.Column<int>(type: "int", nullable: true),
                    OtherPackaging = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    PackagingVerified = table.Column<bool>(type: "bit", nullable: true),
                    PackagingVerifiedBy = table.Column<int>(type: "int", nullable: true),
                    PackagingVerifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PalletBottomPad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletCapacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletCapacityQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletCartons = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletDetailNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletLabel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PalletLabelQty = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PalletNumLayers = table.Column<int>(type: "int", nullable: true),
                    PalletPad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletPadQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletPartitions1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletPartitions1Qty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletPartitions2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletPartitions2Qty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletQty = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PalletTube = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PalletTubeQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrintingPlateNumber = table.Column<int>(type: "int", nullable: true),
                    ProtectiveWrapBoxLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapCartonLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapLabelQty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapOther = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapPartNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapQuantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProtectiveWrapStyle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StdPackId = table.Column<long>(type: "bigint", nullable: true),
                    StdSkId = table.Column<int>(type: "int", nullable: true),
                    Upc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    _3of9 = table.Column<string>(name: "3of9", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Packaging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_PackagingValImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UploadedById = table.Column<int>(type: "int", nullable: true),
                    UploadedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_PackagingValImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Quality",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalNotes = table.Column<string>(type: "ntext", nullable: true),
                    IsChkdBarcodeCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdBoxCloses = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdBoxCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdFilterBoxCloses = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdGraphicIdentCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdLblCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdPackAccToPrint = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdPalletDetail = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdPalletDetailCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdToPrint = table.Column<bool>(type: "bit", nullable: true),
                    IsChkdfilterBox = table.Column<bool>(type: "bit", nullable: true),
                    IsComplete = table.Column<int>(type: "int", nullable: true),
                    PackHeight = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PackLength = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PackWeight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackWidth = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    StandardPackWeight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Trigger",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionTookOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeOrderId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FromUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastReminderOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    RemindDays = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((3))"),
                    ToUserId = table.Column<int>(type: "int", nullable: true),
                    What = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Trigger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Validations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CompletedById = table.Column<int>(type: "int", nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: true),
                    ValidationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Validations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_EngArtworkRequestPlate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    ArkworkRequestId = table.Column<long>(type: "bigint", nullable: false),
                    CatalogNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    filetype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Numbers99 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ulApproved = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_EngArtworkRequestPlate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NACO_EngArtworkRequestPlate_NACO_EngArtworkRequest",
                        column: x => x.ArkworkRequestId,
                        principalTable: "NACO_EngArtworkRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NACO_EngArtworkRequestPlate_ArkworkRequestId",
                table: "NACO_EngArtworkRequestPlate",
                column: "ArkworkRequestId");
        }
    }
}
