using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSize",
                table: "RushShipping");

            migrationBuilder.DropColumn(
                name: "RushDays",
                table: "RushShipping");

            migrationBuilder.AddColumn<string>(
                name: "RushName",
                table: "RushShipping",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RushName",
                table: "RushShipping");

            migrationBuilder.AddColumn<int>(
                name: "MaxSize",
                table: "RushShipping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RushDays",
                table: "RushShipping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
