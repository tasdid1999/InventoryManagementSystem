using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_ProductPrice_ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseProduct_ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropColumn(
                name: "ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_ProductPrice_ProductPriceId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductPriceId",
                principalSchema: "Product",
                principalTable: "ProductPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
