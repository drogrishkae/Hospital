using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDateEntityNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.RenameColumn(
                name: "DayID",
                table: "AppointmentDefinitions",
                newName: "DateEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDefinitions_DayID",
                table: "AppointmentDefinitions",
                newName: "IX_AppointmentDefinitions_DateEntityID");

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    DateEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.DateEntityID);
                    table.ForeignKey(
                        name: "FK_Dates_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dates_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "TimeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "DateEntityID", "Date", "DoctorId", "TimeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 6, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 7, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 8, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 9, new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 10, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 11, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 12, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 13, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 14, new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 15, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 16, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 17, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 18, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 19, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 20, new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 21, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 22, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 23, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 24, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 25, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 26, new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 27, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 28, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 29, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7 },
                    { 30, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7 },
                    { 31, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 32, new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 33, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4 },
                    { 34, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4 },
                    { 35, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 36, new DateTime(2025, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 37, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 38, new DateTime(2025, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 39, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5 },
                    { 40, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5 },
                    { 41, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 6 },
                    { 42, new DateTime(2025, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dates_DoctorId",
                table: "Dates",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_TimeId",
                table: "Dates",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Dates_DateEntityID",
                table: "AppointmentDefinitions",
                column: "DateEntityID",
                principalTable: "Dates",
                principalColumn: "DateEntityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Dates_DateEntityID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.RenameColumn(
                name: "DateEntityID",
                table: "AppointmentDefinitions",
                newName: "DayID");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDefinitions_DateEntityID",
                table: "AppointmentDefinitions",
                newName: "IX_AppointmentDefinitions_DayID");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayID);
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayID", "DayName" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID");
        }
    }
}
