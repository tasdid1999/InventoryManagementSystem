using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.EnsureSchema(
                name: "Shop");

            migrationBuilder.CreateTable(
                name: "Shop",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRoom = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopRack",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    NumberOfRow = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopRack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopRack_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductPriceId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_ProductBrand_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalSchema: "Product",
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_ProductPrice_ProductPriceId",
                        column: x => x.ProductPriceId,
                        principalSchema: "Product",
                        principalTable: "ProductPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreRoom",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    NumberOfRack = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreRoom_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreStockHistory",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    PreviousStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreStockHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreStockHistory_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "storeToShopTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPriceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeToShopTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_storeToShopTransfer_ProductPrice_ProductPriceId",
                        column: x => x.ProductPriceId,
                        principalSchema: "Product",
                        principalTable: "ProductPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_storeToShopTransfer_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_storeToShopTransfer_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_storeToShopTransfer_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopRow",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopRackId = table.Column<int>(type: "int", nullable: false),
                    NumberOfBin = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopRow_ShopRack_ShopRackId",
                        column: x => x.ShopRackId,
                        principalSchema: "Shop",
                        principalTable: "ShopRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreRack",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    NumberOfRow = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreRack_StoreRoom_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "Store",
                        principalTable: "StoreRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopBin",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopRowId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopBin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopBin_ShopRow_ShopRowId",
                        column: x => x.ShopRowId,
                        principalSchema: "Shop",
                        principalTable: "ShopRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreRow",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RackId = table.Column<int>(type: "int", nullable: false),
                    NumberOfBin = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreRow_StoreRack_RackId",
                        column: x => x.RackId,
                        principalSchema: "Store",
                        principalTable: "StoreRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopStock",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopBinId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopStock_ShopBin_ShopBinId",
                        column: x => x.ShopBinId,
                        principalSchema: "Shop",
                        principalTable: "ShopBin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopStock_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreBin",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreBin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreBin_StoreRow_RowId",
                        column: x => x.RowId,
                        principalSchema: "Store",
                        principalTable: "StoreRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStock_StoreBin_BinId",
                        column: x => x.BinId,
                        principalSchema: "Store",
                        principalTable: "StoreBin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStock_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreStock",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreBinId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreStock_StoreBin_StoreBinId",
                        column: x => x.StoreBinId,
                        principalSchema: "Store",
                        principalTable: "StoreBin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreStock_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_BinId",
                schema: "Store",
                table: "ProductStock",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                schema: "Store",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_StoreId",
                schema: "Store",
                table: "ProductStock",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductBrandId",
                schema: "Product",
                table: "Purchase",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductId",
                schema: "Product",
                table: "Purchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductPriceId",
                schema: "Product",
                table: "Purchase",
                column: "ProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_StoreId",
                schema: "Product",
                table: "Purchase",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopBin_ShopRowId",
                schema: "Shop",
                table: "ShopBin",
                column: "ShopRowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopRack_ShopId",
                schema: "Shop",
                table: "ShopRack",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopRow_ShopRackId",
                schema: "Shop",
                table: "ShopRow",
                column: "ShopRackId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopBinId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ShopId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreBin_RowId",
                schema: "Store",
                table: "StoreBin",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRack_RoomId",
                schema: "Store",
                table: "StoreRack",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRoom_StoreId",
                schema: "Store",
                table: "StoreRoom",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRow_RackId",
                schema: "Store",
                table: "StoreRow",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStock_StoreBinId",
                schema: "Store",
                table: "StoreStock",
                column: "StoreBinId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStock_StoreId",
                schema: "Store",
                table: "StoreStock",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStockHistory_StoreId",
                schema: "Store",
                table: "StoreStockHistory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_storeToShopTransfer_ProductId",
                table: "storeToShopTransfer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_storeToShopTransfer_ProductPriceId",
                table: "storeToShopTransfer",
                column: "ProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_storeToShopTransfer_ShopId",
                table: "storeToShopTransfer",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_storeToShopTransfer_StoreId",
                table: "storeToShopTransfer",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStock",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Purchase",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "ShopStock",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "StoreStock",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "StoreStockHistory",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "storeToShopTransfer");

            migrationBuilder.DropTable(
                name: "ShopBin",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "StoreBin",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "ShopRow",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "StoreRow",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "ShopRack",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "StoreRack",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Shop",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "StoreRoom",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Store");
        }
    }
}
