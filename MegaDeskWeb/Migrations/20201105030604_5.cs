using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RushShippingID",
                table: "DeskQuote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RushShipping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxSize = table.Column<int>(nullable: false),
                    RushDays = table.Column<int>(nullable: false),
                    RushPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushShipping", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_RushShippingID",
                table: "DeskQuote",
                column: "RushShippingID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushShipping_RushShippingID",
                table: "DeskQuote",
                column: "RushShippingID",
                principalTable: "RushShipping",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushShipping_RushShippingID",
                table: "DeskQuote");

            migrationBuilder.DropTable(
                name: "RushShipping");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_RushShippingID",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "RushShippingID",
                table: "DeskQuote");
        }
    }
}
