using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTelecomFinal.Migrations
{
    public partial class ChangedTypeOfValueInSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Settings",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Settings",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4000);
        }
    }
}
