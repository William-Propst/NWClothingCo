using Microsoft.EntityFrameworkCore.Migrations;

namespace NWClothingCo.Migrations
{
    public partial class UpdateCartTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cart_No",
                table: "Cart",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cart_No",
                table: "Cart");
        }
    }
}
