using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class purchasetableedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Requsition_RequsitionId",
                schema: "Shop",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_ProductBrand_BrandId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_ProductCatagory_ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopStock");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseProduct_BrandId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_RequsitionId",
                schema: "Shop",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "BrandId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropColumn(
                name: "PurchaseStatus",
                schema: "Shop",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "RequsitionId",
                schema: "Shop",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                newName: "ShopRowId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopStock_ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                newName: "IX_ShopStock_ShopRowId");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "int",
                nullable: true);

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
                name: "IX_PurchaseProduct_ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_ProductBrand_ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductBrandId",
                principalSchema: "Product",
                principalTable: "ProductBrand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_ProductCatagory_ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductCatagoryId",
                principalSchema: "Product",
                principalTable: "ProductCatagory",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_ProductBrand_ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProduct_ProductCatagory_ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct");

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
                name: "IX_PurchaseProduct_ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct");

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
                name: "ProductBrandId",
                schema: "Shop",
                table: "PurchaseProduct");

            migrationBuilder.RenameColumn(
                name: "ShopRowId",
                schema: "Shop",
                table: "ShopStock",
                newName: "ShopBinId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopStock_ShopRowId",
                schema: "Shop",
                table: "ShopStock",
                newName: "IX_ShopStock_ShopBinId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseStatus",
                schema: "Shop",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequsitionId",
                schema: "Shop",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProduct_BrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RequsitionId",
                schema: "Shop",
                table: "Purchase",
                column: "RequsitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Requsition_RequsitionId",
                schema: "Shop",
                table: "Purchase",
                column: "RequsitionId",
                principalSchema: "Product",
                principalTable: "Requsition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_ProductBrand_BrandId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "BrandId",
                principalSchema: "Product",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProduct_ProductCatagory_ProductCatagoryId",
                schema: "Shop",
                table: "PurchaseProduct",
                column: "ProductCatagoryId",
                principalSchema: "Product",
                principalTable: "ProductCatagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopStock",
                column: "ShopBinId",
                principalSchema: "Shop",
                principalTable: "ShopBin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
