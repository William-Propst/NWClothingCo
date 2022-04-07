using Microsoft.EntityFrameworkCore.Migrations;

namespace NWClothingCo.Migrations
{
    public partial class UpdateCustomer_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Order",
                newName: "Customer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Order",
                newName: "User_Id");
        }
    }
}
