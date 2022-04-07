using Microsoft.EntityFrameworkCore.Migrations;

namespace NWClothingCo.Migrations
{
    public partial class addProductToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Product_Desc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Image_Title_1 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Image_Name_1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Image_Title_2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Image_Name_2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Image_Title_3 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Image_Name_3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
