using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopToShopTranfer_Product_ProductId",
                table: "shopToShopTranfer");

            migrationBuilder.DropForeignKey(
                name: "FK_shopToShopTranfer_shopToShopTransfer_ShopToShopTransferId",
                table: "shopToShopTranfer");

            migrationBuilder.DropForeignKey(
                name: "FK_shopToShopTransfer_Shop_FromShopId",
                table: "shopToShopTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_shopToShopTransfer_Shop_ToShopId",
                table: "shopToShopTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopToShopTransfer",
                table: "shopToShopTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopToShopTranfer",
                table: "shopToShopTranfer");

            migrationBuilder.RenameTable(
                name: "shopToShopTransfer",
                newName: "ShopToShopTransfer",
                newSchema: "Shop");

            migrationBuilder.RenameTable(
                name: "shopToShopTranfer",
                newName: "ShopToShopTransferProduct",
                newSchema: "Shop");

            migrationBuilder.RenameIndex(
                name: "IX_shopToShopTransfer_ToShopId",
                schema: "Shop",
                table: "ShopToShopTransfer",
                newName: "IX_ShopToShopTransfer_ToShopId");

            migrationBuilder.RenameIndex(
                name: "IX_shopToShopTransfer_FromShopId",
                schema: "Shop",
                table: "ShopToShopTransfer",
                newName: "IX_ShopToShopTransfer_FromShopId");

            migrationBuilder.RenameIndex(
                name: "IX_shopToShopTranfer_ShopToShopTransferId",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                newName: "IX_ShopToShopTransferProduct_ShopToShopTransferId");

            migrationBuilder.RenameIndex(
                name: "IX_shopToShopTranfer_ProductId",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                newName: "IX_ShopToShopTransferProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopToShopTransfer",
                schema: "Shop",
                table: "ShopToShopTransfer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopToShopTransferProduct",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopToShopTransfer_Shop_FromShopId",
                schema: "Shop",
                table: "ShopToShopTransfer",
                column: "FromShopId",
                principalSchema: "Shop",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopToShopTransfer_Shop_ToShopId",
                schema: "Shop",
                table: "ShopToShopTransfer",
                column: "ToShopId",
                principalSchema: "Shop",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopToShopTransferProduct_Product_ProductId",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopToShopTransferProduct_ShopToShopTransfer_ShopToShopTransferId",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                column: "ShopToShopTransferId",
                principalSchema: "Shop",
                principalTable: "ShopToShopTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopToShopTransfer_Shop_FromShopId",
                schema: "Shop",
                table: "ShopToShopTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopToShopTransfer_Shop_ToShopId",
                schema: "Shop",
                table: "ShopToShopTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopToShopTransferProduct_Product_ProductId",
                schema: "Shop",
                table: "ShopToShopTransferProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopToShopTransferProduct_ShopToShopTransfer_ShopToShopTransferId",
                schema: "Shop",
                table: "ShopToShopTransferProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopToShopTransfer",
                schema: "Shop",
                table: "ShopToShopTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopToShopTransferProduct",
                schema: "Shop",
                table: "ShopToShopTransferProduct");

            migrationBuilder.RenameTable(
                name: "ShopToShopTransfer",
                schema: "Shop",
                newName: "shopToShopTransfer");

            migrationBuilder.RenameTable(
                name: "ShopToShopTransferProduct",
                schema: "Shop",
                newName: "shopToShopTranfer");

            migrationBuilder.RenameIndex(
                name: "IX_ShopToShopTransfer_ToShopId",
                table: "shopToShopTransfer",
                newName: "IX_shopToShopTransfer_ToShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopToShopTransfer_FromShopId",
                table: "shopToShopTransfer",
                newName: "IX_shopToShopTransfer_FromShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopToShopTransferProduct_ShopToShopTransferId",
                table: "shopToShopTranfer",
                newName: "IX_shopToShopTranfer_ShopToShopTransferId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopToShopTransferProduct_ProductId",
                table: "shopToShopTranfer",
                newName: "IX_shopToShopTranfer_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopToShopTransfer",
                table: "shopToShopTransfer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopToShopTranfer",
                table: "shopToShopTranfer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shopToShopTranfer_Product_ProductId",
                table: "shopToShopTranfer",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shopToShopTranfer_shopToShopTransfer_ShopToShopTransferId",
                table: "shopToShopTranfer",
                column: "ShopToShopTransferId",
                principalTable: "shopToShopTransfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shopToShopTransfer_Shop_FromShopId",
                table: "shopToShopTransfer",
                column: "FromShopId",
                principalSchema: "Shop",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shopToShopTransfer_Shop_ToShopId",
                table: "shopToShopTransfer",
                column: "ToShopId",
                principalSchema: "Shop",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
