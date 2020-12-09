using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class RemoveEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Meeting_MeetingID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "SpeakerEnrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_MeetingID",
                table: "SpeakerEnrollment",
                newName: "IX_SpeakerEnrollment_MeetingID");

            migrationBuilder.AddColumn<int>(
                name: "MeetingID",
                table: "Speaker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEnrollment",
                table: "SpeakerEnrollment",
                column: "SpeakerEnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEnrollment_Meeting_MeetingID",
                table: "SpeakerEnrollment",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEnrollment_Meeting_MeetingID",
                table: "SpeakerEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEnrollment",
                table: "SpeakerEnrollment");

            migrationBuilder.DropColumn(
                name: "MeetingID",
                table: "Speaker");

            migrationBuilder.RenameTable(
                name: "SpeakerEnrollment",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEnrollment_MeetingID",
                table: "Enrollment",
                newName: "IX_Enrollment_MeetingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "SpeakerEnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Meeting_MeetingID",
                table: "Enrollment",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
