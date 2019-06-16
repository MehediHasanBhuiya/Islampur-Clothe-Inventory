using Microsoft.EntityFrameworkCore.Migrations;

namespace IslampurClotheEnventory.Data.Migrations
{
    public partial class initial_3_purchesinfo_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchesQuentity",
                table: "PurchesInfos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchesQuentity",
                table: "PurchesInfos");
        }
    }
}
