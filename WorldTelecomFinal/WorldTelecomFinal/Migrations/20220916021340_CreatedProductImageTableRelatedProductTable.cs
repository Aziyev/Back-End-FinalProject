using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTelecomFinal.Migrations
{
    public partial class CreatedProductImageTableRelatedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagId",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.RenameTable(
                name: "ProductTag",
                newName: "ProductsTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagId",
                table: "ProductsTag",
                newName: "IX_ProductsTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_ProductId",
                table: "ProductsTag",
                newName: "IX_ProductsTag_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsTag",
                table: "ProductsTag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductsImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsImage_ProductId",
                table: "ProductsImage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTag_Products_ProductId",
                table: "ProductsTag",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTag_Tags_TagId",
                table: "ProductsTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTag_Products_ProductId",
                table: "ProductsTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTag_Tags_TagId",
                table: "ProductsTag");

            migrationBuilder.DropTable(
                name: "ProductsImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsTag",
                table: "ProductsTag");

            migrationBuilder.RenameTable(
                name: "ProductsTag",
                newName: "ProductTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsTag_TagId",
                table: "ProductTag",
                newName: "IX_ProductTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsTag_ProductId",
                table: "ProductTag",
                newName: "IX_ProductTag_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductId",
                table: "ProductTag",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagId",
                table: "ProductTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
