using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentDefinitions_AppointmentDefinitionsID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentDefinitionsID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDefinitionsID",
                table: "Appointments",
                newName: "DoctorID");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments",
                column: "AppointmentDefinitionsAppointmentDefinitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentDefinitions_AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments",
                column: "AppointmentDefinitionsAppointmentDefinitionID",
                principalTable: "AppointmentDefinitions",
                principalColumn: "AppointmentDefinitionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentDefinitions_AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentDefinitionsAppointmentDefinitionID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Appointments",
                newName: "AppointmentDefinitionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDefinitionsID",
                table: "Appointments",
                column: "AppointmentDefinitionsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentDefinitions_AppointmentDefinitionsID",
                table: "Appointments",
                column: "AppointmentDefinitionsID",
                principalTable: "AppointmentDefinitions",
                principalColumn: "AppointmentDefinitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
