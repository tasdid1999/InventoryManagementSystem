using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shopStockmanage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_Product_ProductId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_ShopBin_BinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_ShopRack_ShopRackId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_ShopRow_ShopRowId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopStock_BinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopStock_ProductId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopStock_ShopRackId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopStock_ShopRowId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "BinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "RackId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "RowId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "ShopRackId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "ShopRowId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.AddColumn<int>(
                name: "ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopProductStock",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RackId = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    ShopBinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShopStockId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopBin_ShopBinId",
                        column: x => x.ShopBinId,
                        principalSchema: "Shop",
                        principalTable: "ShopBin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopRack_RackId",
                        column: x => x.RackId,
                        principalSchema: "Shop",
                        principalTable: "ShopRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopRow_RowId",
                        column: x => x.RowId,
                        principalSchema: "Shop",
                        principalTable: "ShopRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductStock_ShopStock_ShopStockId",
                        column: x => x.ShopStockId,
                        principalSchema: "Shop",
                        principalTable: "ShopStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopBinId");

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
                name: "IX_ShopProductStock_ShopBinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ShopBinId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_ShopStockId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ShopStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopBinId",
                principalSchema: "Shop",
                principalTable: "ShopBin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropTable(
                name: "ShopProductStock",
                schema: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_ShopStock_ShopBinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropColumn(
                name: "ShopBinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.AddColumn<int>(
                name: "BinId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RackId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopRackId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopRowId",
                schema: "Shop",
                table: "ShopStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_BinId",
                schema: "Shop",
                table: "ShopStock",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ProductId",
                schema: "Shop",
                table: "ShopStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ShopRackId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopRackId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopStock_ShopRowId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_Product_ProductId",
                schema: "Shop",
                table: "ShopStock",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_ShopBin_BinId",
                schema: "Shop",
                table: "ShopStock",
                column: "BinId",
                principalSchema: "Shop",
                principalTable: "ShopBin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_ShopRack_ShopRackId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopRackId",
                principalSchema: "Shop",
                principalTable: "ShopRack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_ShopRow_ShopRowId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopRowId",
                principalSchema: "Shop",
                principalTable: "ShopRow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
