using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reqo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_ProductBrand_ProductBrandId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Store_StoreId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                schema: "Product",
                table: "Purchase",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                schema: "Product",
                table: "Purchase",
                newName: "RequsitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_StoreId",
                schema: "Product",
                table: "Purchase",
                newName: "IX_Purchase_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ProductBrandId",
                schema: "Product",
                table: "Purchase",
                newName: "IX_Purchase_RequsitionId");

            migrationBuilder.CreateTable(
                name: "Requsition",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requsition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequsitionDetails",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequsitionId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequsitionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequsitionDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequsitionDetails_Requsition_RequsitionId",
                        column: x => x.RequsitionId,
                        principalSchema: "Product",
                        principalTable: "Requsition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequsitionDetails_ProductId",
                schema: "Product",
                table: "RequsitionDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RequsitionDetails_RequsitionId",
                schema: "Product",
                table: "RequsitionDetails",
                column: "RequsitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requsition_RequsitionId",
                schema: "Product",
                table: "Purchase",
                column: "RequsitionId",
                principalSchema: "Product",
                principalTable: "Requsition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Shop_ShopId",
                schema: "Product",
                table: "Purchase",
                column: "ShopId",
                principalSchema: "Shop",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requsition_RequsitionId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Shop_ShopId",
                schema: "Product",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "RequsitionDetails",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Requsition",
                schema: "Product");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                schema: "Product",
                table: "Purchase",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "RequsitionId",
                schema: "Product",
                table: "Purchase",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ShopId",
                schema: "Product",
                table: "Purchase",
                newName: "IX_Purchase_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_RequsitionId",
                schema: "Product",
                table: "Purchase",
                newName: "IX_Purchase_ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_ProductBrand_ProductBrandId",
                schema: "Product",
                table: "Purchase",
                column: "ProductBrandId",
                principalSchema: "Product",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Store_StoreId",
                schema: "Product",
                table: "Purchase",
                column: "StoreId",
                principalSchema: "Store",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
