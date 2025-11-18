using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberIdToAppointmentDefinitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDefinitions_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_AspNetUsers_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_AspNetUsers_MemberId",
                table: "AppointmentDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDefinitions_MemberId",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "AppointmentDefinitions");
        }
    }
}