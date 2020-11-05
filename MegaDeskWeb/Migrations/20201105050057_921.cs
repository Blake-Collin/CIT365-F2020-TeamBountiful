using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class _921 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_DeskMaterial_materialID",
                table: "Desk");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "productionDays",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "deskID",
                table: "DeskQuote",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "materialID",
                table: "Desk",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_DeskMaterial_materialID",
                table: "Desk",
                column: "materialID",
                principalTable: "DeskMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote",
                column: "deskID",
                principalTable: "Desk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_DeskMaterial_materialID",
                table: "Desk");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "deskID",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productionDays",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "materialID",
                table: "Desk",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_DeskMaterial_materialID",
                table: "Desk",
                column: "materialID",
                principalTable: "DeskMaterial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote",
                column: "deskID",
                principalTable: "Desk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
