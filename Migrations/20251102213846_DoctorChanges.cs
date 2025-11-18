using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DoctorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolyclinicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_Polyclinics_PolyclinicID",
                        column: x => x.PolyclinicID,
                        principalTable: "Polyclinics",
                        principalColumn: "PolyclinicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDefinitions_DoctorID",
                table: "AppointmentDefinitions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PolyclinicID",
                table: "Doctors",
                column: "PolyclinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Doctors_DoctorID",
                table: "AppointmentDefinitions",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Doctors_DoctorID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDefinitions_DoctorID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "AppointmentDefinitions");
        }
    }
}
