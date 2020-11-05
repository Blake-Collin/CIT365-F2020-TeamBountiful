using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "customerName",
                table: "DeskQuote",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "deskID",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "quoteAmount",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DeskMaterial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeskMaterialName = table.Column<string>(nullable: true),
                    DeskMaterialPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskMaterial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deskWidth = table.Column<int>(nullable: false),
                    deskDepth = table.Column<int>(nullable: false),
                    numOfDrawers = table.Column<int>(nullable: false),
                    materialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Desk_DeskMaterial_materialID",
                        column: x => x.materialID,
                        principalTable: "DeskMaterial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_deskID",
                table: "DeskQuote",
                column: "deskID");

            migrationBuilder.CreateIndex(
                name: "IX_Desk_materialID",
                table: "Desk",
                column: "materialID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote",
                column: "deskID",
                principalTable: "Desk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Desk_deskID",
                table: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "DeskMaterial");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_deskID",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "deskID",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "quoteAmount",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<string>(
                name: "customerName",
                table: "DeskQuote",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
