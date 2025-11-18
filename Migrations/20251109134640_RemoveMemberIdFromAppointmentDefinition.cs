using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMemberIdFromAppointmentDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Members_MemberId",
                table: "AppointmentDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDefinitions_MemberId",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "AppointmentDefinitions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDefinitions_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Members_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
