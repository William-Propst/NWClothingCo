using Microsoft.EntityFrameworkCore.Migrations;

namespace NWClothingCo.Migrations
{
    public partial class addCategoryToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image_Title_1",
                table: "Product",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "navarchar(50)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Category_Desc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Category_Image_Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Category_Image_Name = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Image_Title_1",
                table: "Product",
                type: "navarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}
