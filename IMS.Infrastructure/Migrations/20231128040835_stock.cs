using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopProductStock_ShopBinId",
                schema: "Shop",
                table: "ShopProductStock");

            migrationBuilder.DropColumn(
                name: "ShopBinId",
                schema: "Shop",
                table: "ShopProductStock");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_BinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "BinId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProductStock_ShopBin_BinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "BinId",
                principalSchema: "Shop",
                principalTable: "ShopBin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductStock_ShopBin_BinId",
                schema: "Shop",
                table: "ShopProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ShopProductStock_BinId",
                schema: "Shop",
                table: "ShopProductStock");

            migrationBuilder.AddColumn<int>(
                name: "ShopBinId",
                schema: "Shop",
                table: "ShopProductStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductStock_ShopBinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ShopBinId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProductStock_ShopBin_ShopBinId",
                schema: "Shop",
                table: "ShopProductStock",
                column: "ShopBinId",
                principalSchema: "Shop",
                principalTable: "ShopBin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
