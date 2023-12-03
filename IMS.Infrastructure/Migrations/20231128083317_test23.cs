using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopToShopTranferId",
                schema: "Shop",
                table: "ShopToShopTransferProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopToShopTranferId",
                schema: "Shop",
                table: "ShopToShopTransferProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
