using Microsoft.EntityFrameworkCore.Migrations;

namespace IslampurClotheEnventory.Data.Migrations
{
    public partial class secoundupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Products",
                newName: "ProductSalePrice");

            migrationBuilder.AddColumn<double>(
                name: "ProductPurchesPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPurchesPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductSalePrice",
                table: "Products",
                newName: "ProductPrice");
        }
    }
}
