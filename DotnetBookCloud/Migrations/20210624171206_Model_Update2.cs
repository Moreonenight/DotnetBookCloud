using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetBookCloud.Migrations
{
    public partial class Model_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "telegram",
                table: "Orders",
                newName: "Telephone");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceivedTime",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Orders",
                newName: "telegram");
        }
    }
}
