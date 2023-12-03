using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "storeToShopTransfer");

          

            migrationBuilder.CreateTable(
                name: "shopToShopTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromShopId = table.Column<int>(type: "int", nullable: false),
                    ToShopId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopToShopTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopToShopTransfer_Shop_FromShopId",
                        column: x => x.FromShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shopToShopTransfer_Shop_ToShopId",
                        column: x => x.ToShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shopToShopTranfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopToShopTranferId = table.Column<int>(type: "int", nullable: false),
                    ShopToShopTransferId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopToShopTranfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopToShopTranfer_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shopToShopTranfer_shopToShopTransfer_ShopToShopTransferId",
                        column: x => x.ShopToShopTransferId,
                        principalTable: "shopToShopTransfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopToShopTranfer_ProductId",
                table: "shopToShopTranfer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shopToShopTranfer_ShopToShopTransferId",
                table: "shopToShopTranfer",
                column: "ShopToShopTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_shopToShopTransfer_FromShopId",
                table: "shopToShopTransfer",
                column: "FromShopId");

            migrationBuilder.CreateIndex(
                name: "IX_shopToShopTransfer_ToShopId",
                table: "shopToShopTransfer",
                column: "ToShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopToShopTranfer");

            migrationBuilder.DropTable(
                name: "shopToShopTransfer");

            migrationBuilder.CreateTable(
                name: "ShopStock",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ShopBinId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopStock_ShopBin_ShopBinId",
                        column: x => x.ShopBinId,
                        principalSchema: "Shop",
                        principalTable: "ShopBin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopStock_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Shop",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "storeToShopTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPriceId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
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
                name: "ShopProductStock",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RackId = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    ShopStockId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopBin_BinId",
                        column: x => x.BinId,
                        principalSchema: "Shop",
                        principalTable: "ShopBin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopRack_RackId",
                        column: x => x.RackId,
                        principalSchema: "Shop",
                        principalTable: "ShopRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopRow_RowId",
                        column: x => x.RowId,
                        principalSchema: "Shop",
                        principalTable: "ShopRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopStock_ShopStockId",
                        column: x => x.ShopStockId,
                        principalSchema: "Shop",
                        principalTable: "ShopStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_BinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_ProductId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_RackId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_RowId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_ShopStockId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ShopStockId");

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
    }
}
