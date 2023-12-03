using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class purchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_ProductPrice_ProductPriceId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Product_ProductId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ProductId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ProductPriceId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                schema: "Product",
                newName: "Purchase",
                newSchema: "Shop");

            migrationBuilder.RenameColumn(
                name: "ProductPriceId",
                schema: "Shop",
                table: "Purchase",
                newName: "PurchaseStatus");

            migrationBuilder.CreateTable(
                name: "PurchaseProduct",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPriceId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false),
                    ProductCatagoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProduct_ProductBrand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Product",
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseProduct_ProductCatagory_ProductCatagoryId",
                        column: x => x.ProductCatagoryId,
                        principalSchema: "Product",
                        principalTable: "ProductCatagory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseProduct_ProductPrice_ProductPriceId",
                        column: x => x.ProductPriceId,
                        principalSchema: "Product",
                        principalTable: "ProductPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseProduct_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Shop",
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_BrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_ProductId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_PurchaseId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseProduct",
                schema: "Shop");

            migrationBuilder.RenameTable(
                name: "Purchase",
                schema: "Shop",
                newName: "Purchase",
                newSchema: "Product");

            migrationBuilder.RenameColumn(
                name: "PurchaseStatus",
                schema: "Product",
                table: "Purchase",
                newName: "ProductPriceId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "Product",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_ProductPrice_ProductPriceId",
                schema: "Product",
                table: "Purchase",
                column: "ProductPriceId",
                principalSchema: "Product",
                principalTable: "ProductPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Product_ProductId",
                schema: "Product",
                table: "Purchase",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
