using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class AddedEnrollmentList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "MeetingID",
                table: "Speaker");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MeetingID",
                table: "Enrollment",
                column: "MeetingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Meeting_MeetingID",
                table: "Enrollment",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Meeting_MeetingID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_MeetingID",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "MeetingID",
                table: "Speaker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker",
                column: "MeetingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
