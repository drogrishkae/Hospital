using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "DayID",
                table: "Appointment_VMs");

            migrationBuilder.AlterColumn<int>(
                name: "DayID",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AppointmentDefinitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointment_VMs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "AppointmentDefinitions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointment_VMs");

            migrationBuilder.AlterColumn<int>(
                name: "DayID",
                table: "AppointmentDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayID",
                table: "Appointment_VMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDefinitions_Days_DayID",
                table: "AppointmentDefinitions",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
