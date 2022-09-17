using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTelecomFinal.Migrations
{
    public partial class CreatedProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DiscoutnPrice = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MainImage = table.Column<string>(maxLength: 255, nullable: true),
                    IsAviable = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Screen = table.Column<int>(nullable: false),
                    RAM = table.Column<int>(nullable: false),
                    CPU = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Momery = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
