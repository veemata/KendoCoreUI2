using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MH.PLCM.Data.Migrations
{
    public partial class Naco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NACO_EngArtworkRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsNewPart = table.Column<int>(nullable: true),
                    RequestorId = table.Column<int>(nullable: true),
                    ArtWorkOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Height = table.Column<string>(maxLength: 30, nullable: true),
                    PanelCenterLine = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    FilterTypeId = table.Column<long>(nullable: true),
                    NumOfTurns = table.Column<int>(nullable: true),
                    Style = table.Column<int>(nullable: true),
                    Panel1 = table.Column<int>(nullable: true),
                    Panel2 = table.Column<int>(nullable: true),
                    Panel3 = table.Column<int>(nullable: true),
                    Panel4 = table.Column<int>(nullable: true),
                    BackPanel = table.Column<int>(nullable: true),
                    TorqueNumbers = table.Column<int>(nullable: true),
                    CautionStatement = table.Column<int>(nullable: true),
                    RunOnLine = table.Column<string>(maxLength: 50, nullable: true),
                    PlateOrientation = table.Column<int>(nullable: true),
                    DoubleseamLocation = table.Column<string>(maxLength: 50, nullable: true),
                    SpecialInstructions = table.Column<string>(type: "ntext", nullable: true),
                    IsUlListing = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_EngArtworkRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Engineering",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUlListing = table.Column<int>(nullable: true),
                    IsPurchasedProduct = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    SupplierPartNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ManufacturerPartNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PurchasedEleSupplier = table.Column<string>(maxLength: 50, nullable: true),
                    PackagingFilterTypeId = table.Column<long>(nullable: true),
                    IsPPAPRequired = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    PPAPLevelId = table.Column<long>(nullable: true),
                    PPAPDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PPAPQty = table.Column<int>(nullable: true),
                    QualityContact = table.Column<string>(maxLength: 50, nullable: true),
                    QualityContactPhone = table.Column<string>(maxLength: 50, nullable: true),
                    EngineerId = table.Column<long>(nullable: true),
                    DesignerId = table.Column<long>(nullable: true),
                    ToolingPaidBy = table.Column<string>(maxLength: 50, nullable: true),
                    TotalToolingCost = table.Column<double>(nullable: true),
                    TotalDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignValidationLevel = table.Column<int>(nullable: true),
                    DeptCodeId = table.Column<long>(nullable: true),
                    CountryOfOrigin = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    IsSupPPAPRequired = table.Column<byte>(nullable: false),
                    CustomerSafetyStock = table.Column<double>(nullable: false),
                    FirstShipId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Engineering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Filter",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementLength = table.Column<string>(maxLength: 15, nullable: true),
                    ElementHeight = table.Column<string>(maxLength: 15, nullable: true),
                    ElementWidth = table.Column<string>(maxLength: 15, nullable: true),
                    ElementThread = table.Column<int>(nullable: true),
                    FilterWeight = table.Column<string>(maxLength: 15, nullable: true),
                    OuterDiameterTop = table.Column<string>(maxLength: 15, nullable: true),
                    InnerDiameterTop = table.Column<string>(maxLength: 15, nullable: true),
                    OuterDiameterBottom = table.Column<string>(maxLength: 15, nullable: true),
                    InnerDiameterBottom = table.Column<string>(maxLength: 15, nullable: true),
                    Other = table.Column<string>(maxLength: 15, nullable: true),
                    ElementIdentinfication = table.Column<int>(nullable: true),
                    PaintColorId = table.Column<long>(nullable: true),
                    PaintPartNumber = table.Column<int>(nullable: true),
                    Inkcolor1 = table.Column<int>(nullable: true),
                    InkpartNumber1 = table.Column<int>(nullable: true),
                    Inkcolor2 = table.Column<int>(nullable: true),
                    InkpartNumber2 = table.Column<int>(nullable: true),
                    Identification = table.Column<string>(maxLength: 2500, nullable: true),
                    PaintPlateIdentification = table.Column<string>(maxLength: 50, nullable: true),
                    PlateOrientation = table.Column<int>(nullable: true),
                    IDMethodId = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('None')"),
                    PrintPlate1PartNo = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    PrintPlate2PartNo = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    MasterPlatePartNo = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    InnerDiameterLabelPartNo = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Filter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_History",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(nullable: true),
                    ChangingUserId = table.Column<int>(nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChangeDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Filename = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_MSS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualEOQ = table.Column<int>(nullable: true),
                    ActualInitialRun = table.Column<int>(nullable: true),
                    PlannerId = table.Column<long>(nullable: true),
                    SelectionCodeId = table.Column<long>(nullable: true),
                    OrderIntervalId = table.Column<long>(nullable: true),
                    BillOfLadingId = table.Column<long>(nullable: true),
                    NOQMOQ = table.Column<int>(nullable: true),
                    ScheduledOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualStandardCost = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_MSS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_NewPart",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ItemDescription = table.Column<string>(maxLength: 500, nullable: true),
                    PurchaseMenu = table.Column<string>(maxLength: 50, nullable: true),
                    ToolingCost = table.Column<string>(maxLength: 50, nullable: true),
                    ToolingOrdered = table.Column<bool>(nullable: true),
                    ToolingOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToolingDueDateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PpapLevel = table.Column<int>(nullable: true),
                    PpapQty = table.Column<int>(nullable: true),
                    Complete = table.Column<bool>(nullable: true),
                    PrintComplete = table.Column<bool>(nullable: true),
                    PrintCompletedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrintReleased = table.Column<bool>(nullable: true),
                    PrintReleasedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductCode = table.Column<bool>(nullable: true),
                    IsActive = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    NPrev = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    NPsheet = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    DrawingFile = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_NewPart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Packaging",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxNum = table.Column<string>(maxLength: 50, nullable: true),
                    BoxPrint = table.Column<string>(maxLength: 50, nullable: true),
                    BoxGraphics = table.Column<string>(maxLength: 50, nullable: true),
                    BoxSize = table.Column<string>(maxLength: 50, nullable: true),
                    BoxMaterial = table.Column<string>(maxLength: 50, nullable: true),
                    BoxLabel = table.Column<string>(maxLength: 50, nullable: true),
                    BoxCountry = table.Column<string>(maxLength: 50, nullable: true),
                    CartonNum = table.Column<string>(maxLength: 50, nullable: true),
                    CartonGraphics = table.Column<string>(maxLength: 50, nullable: true),
                    CartonSize = table.Column<string>(maxLength: 50, nullable: true),
                    CartonQty = table.Column<string>(maxLength: 50, nullable: true),
                    CartonLabel = table.Column<string>(maxLength: 50, nullable: true),
                    CartonLabelQty = table.Column<string>(maxLength: 50, nullable: true),
                    CartonStenmark = table.Column<string>(maxLength: 50, nullable: true),
                    CartonCountry = table.Column<string>(maxLength: 50, nullable: true),
                    CartonOther = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapStyle = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapPartNum = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapSize = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapQuantity = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapLabel = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapLabelQty = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapCountry = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapCartonLabel = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapBoxLabel = table.Column<string>(maxLength: 50, nullable: true),
                    ProtectiveWrapOther = table.Column<string>(maxLength: 50, nullable: true),
                    PalletDetail = table.Column<string>(maxLength: 50, nullable: true),
                    PalletDetailNum = table.Column<string>(maxLength: 50, nullable: true),
                    PalletCartons = table.Column<string>(maxLength: 50, nullable: true),
                    PalletNumLayers = table.Column<int>(nullable: true),
                    PalletQty = table.Column<string>(maxLength: 20, nullable: true),
                    PalletLabel = table.Column<string>(maxLength: 20, nullable: true),
                    PalletLabelQty = table.Column<string>(maxLength: 8, nullable: true),
                    PalletCountry = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPartitions1 = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPartitions1Qty = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPartitions2 = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPartitions2Qty = table.Column<string>(maxLength: 50, nullable: true),
                    PalletCapacity = table.Column<string>(maxLength: 50, nullable: true),
                    PalletCapacityQty = table.Column<string>(maxLength: 50, nullable: true),
                    PalletTube = table.Column<string>(maxLength: 50, nullable: true),
                    PalletTubeQty = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPad = table.Column<string>(maxLength: 50, nullable: true),
                    PalletPadQty = table.Column<string>(maxLength: 50, nullable: true),
                    PalletBottomPad = table.Column<string>(maxLength: 50, nullable: true),
                    OtherPackaging = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    IsUpcPrefix = table.Column<int>(nullable: true),
                    Upc = table.Column<string>(maxLength: 50, nullable: true),
                    I2of5 = table.Column<string>(maxLength: 50, nullable: true),
                    _3of9 = table.Column<string>(name: "3of9", maxLength: 50, nullable: true),
                    BarCodeId = table.Column<long>(nullable: true),
                    IsRoundFullCarton = table.Column<int>(nullable: true),
                    StdPackId = table.Column<long>(nullable: true),
                    PrintingPlateNumber = table.Column<int>(nullable: true),
                    DateCodeSpec = table.Column<string>(maxLength: 50, nullable: true),
                    StdSkId = table.Column<int>(nullable: true),
                    PackagingVerified = table.Column<bool>(nullable: true),
                    PackagingVerifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PackagingVerifiedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Packaging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_PackagingValImages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: true),
                    UploadedById = table.Column<int>(nullable: true),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsComplete = table.Column<int>(nullable: true),
                    PackHeight = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PackLength = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PackWidth = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    PackWeight = table.Column<string>(maxLength: 50, nullable: true),
                    IsChkdGraphicIdentCorrect = table.Column<bool>(nullable: true),
                    IsChkdLblCorrect = table.Column<bool>(nullable: true),
                    IsChkdBarcodeCorrect = table.Column<bool>(nullable: true),
                    IsChkdBoxCorrect = table.Column<bool>(nullable: true),
                    IsChkdFilterBoxCloses = table.Column<bool>(nullable: true),
                    IsChkdPackAccToPrint = table.Column<bool>(nullable: true),
                    IsChkdPalletDetailCorrect = table.Column<bool>(nullable: true),
                    StandardPackWeight = table.Column<string>(maxLength: 50, nullable: true),
                    AdditionalNotes = table.Column<string>(type: "ntext", nullable: true),
                    IsChkdfilterBox = table.Column<bool>(nullable: true),
                    IsChkdToPrint = table.Column<bool>(nullable: true),
                    IsChkdBoxCloses = table.Column<bool>(nullable: true),
                    IsChkdPalletDetail = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Trigger",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(nullable: false),
                    FromUserId = table.Column<long>(nullable: true),
                    ToUserId = table.Column<int>(nullable: true),
                    What = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "('')"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionTookOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Department = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastReminderOn = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    RemindDays = table.Column<int>(nullable: true, defaultValueSql: "((3))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Trigger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_Validations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeOrderId = table.Column<long>(nullable: true),
                    ValidationId = table.Column<long>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NACO_Validations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NACO_EngArtworkRequestPlate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArkworkRequestId = table.Column<long>(nullable: false),
                    CatalogNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    Numbers99 = table.Column<string>(maxLength: 50, nullable: true),
                    ulApproved = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    filetype = table.Column<string>(maxLength: 50, nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
