using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveObsoleteColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_AppointmentDefinitions_ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDefinitions_ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDefinitions_ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions",
                column: "ParentAppointmentDefinitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_AppointmentDefinitions_ParentAppointmentDefinitionID",
                table: "AppointmentDefinitions",
                column: "ParentAppointmentDefinitionID",
                principalTable: "AppointmentDefinitions",
                principalColumn: "AppointmentDefinitionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
