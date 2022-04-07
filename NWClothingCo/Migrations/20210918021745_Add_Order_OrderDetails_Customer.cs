using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NWClothingCo.Migrations
{
    public partial class Add_Order_OrderDetails_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Address_Line1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Address_Line2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Oder_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_No = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Order_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Order_Total = table.Column<double>(type: "float", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Delivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Oder_Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    Order_Details_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Qty = table.Column<int>(type: "int", nullable: false),
                    Product_Price = table.Column<double>(type: "float", nullable: false),
                    Order_Total = table.Column<double>(type: "float", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.Order_Details_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Order_Details");
        }
    }
}
