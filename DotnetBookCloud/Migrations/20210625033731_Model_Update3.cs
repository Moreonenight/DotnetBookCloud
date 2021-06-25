using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetBookCloud.Migrations
{
    public partial class Model_Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "OrderItems",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderItems");
        }
    }
}
