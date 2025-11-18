using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnMemberId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDefinitions_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Members_MemberId",
                table: "AppointmentDefinitions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
