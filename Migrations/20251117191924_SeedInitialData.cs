using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Times table
            //migrationBuilder.CreateTable(
            //    name: "Times",
            //    columns: table => new
            //    {
            //        TimeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AppointmentTimes = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Times", x => x.TimeID);
            //    });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeID", "AppointmentTimes" },
                values: new object[,]
                {
                    { 1, "10" },
                    { 2, "11" },
                    { 3, "12" },
                    { 4, "13" },
                    { 5, "14" },
                    { 6, "15" },
                    { 7, "16" }
                });

            // Create Dates table
            //migrationBuilder.CreateTable(
            //    name: "Dates",
            //    columns: table => new
            //    {
            //        DateEntityID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Date = table.Column<DateTime>(nullable: false),
            //        DoctorId = table.Column<int>(nullable: false),
            //        TimeId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Dates", x => x.DateEntityID);
            //        table.ForeignKey(
            //            name: "FK_Dates_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "DoctorID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Dates_Times_TimeId",
            //            column: x => x.TimeId,
            //            principalTable: "Times",
            //            principalColumn: "TimeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dates_DoctorId",
            //    table: "Dates",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dates_TimeId",
            //    table: "Dates",
            //    column: "TimeId");

            // Seed Dates table
            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "DateEntityID", "Date", "DoctorId", "TimeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 12), 1, 1 },
                    { 2, new DateTime(2025, 12, 13), 2, 2 },
                    { 3, new DateTime(2025, 12, 14), 3, 3 },
                    { 4, new DateTime(2025, 12, 15), 4, 4 },
                    { 5, new DateTime(2025, 12, 16), 5, 5 },
                    { 6, new DateTime(2025, 12, 17), 6, 6 },
                    { 7, new DateTime(2025, 12, 12), 1, 7 },
                    { 8, new DateTime(2025, 12, 13), 2, 1 },
                    { 9, new DateTime(2025, 12, 14), 3, 2 },
                    { 10, new DateTime(2025, 12, 15), 4, 3 },
                    { 11, new DateTime(2025, 12, 16), 5, 4 },
                    { 12, new DateTime(2025, 12, 17), 6, 5 },
                    { 13, new DateTime(2025, 12, 18), 1, 6 },
                    { 14, new DateTime(2025, 12, 19), 2, 7 },
                    { 15, new DateTime(2025, 12, 20), 3, 1 },
                    { 16, new DateTime(2025, 12, 12), 4, 2 },
                    { 17, new DateTime(2025, 12, 16), 5, 3 },
                    { 18, new DateTime(2025, 12, 15), 6, 4 },
                    { 19, new DateTime(2025, 12, 18), 1, 5 },
                    { 20, new DateTime(2025, 12, 19), 2, 6 },
                    { 21, new DateTime(2025, 12, 20), 3, 7 },
                    { 22, new DateTime(2025, 12, 12), 4, 1 },
                    { 23, new DateTime(2025, 12, 16), 5, 2 },
                    { 24, new DateTime(2025, 12, 15), 6, 3 },
                    { 25, new DateTime(2025, 12, 18), 1, 4 },
                    { 26, new DateTime(2025, 12, 19), 2, 5 },
                    { 27, new DateTime(2025, 12, 20), 3, 6 },
                    { 28, new DateTime(2025, 12, 12), 4, 7 },
                    { 29, new DateTime(2025, 12, 16), 5, 1 },
                    { 30, new DateTime(2025, 12, 15), 6, 2 },
                    { 31, new DateTime(2025, 12, 13), 1, 3 },
                    { 32, new DateTime(2025, 12, 14), 2, 4 },
                    { 33, new DateTime(2025, 12, 18), 3, 5 },
                    { 34, new DateTime(2025, 12, 20), 4, 6 },
                    { 35, new DateTime(2025, 12, 22), 5, 7 },
                    { 36, new DateTime(2025, 12, 23), 6, 1 },
                    { 37, new DateTime(2025, 12, 10), 1, 2 },
                    { 38, new DateTime(2025, 12, 11), 2, 3 },
                    { 39, new DateTime(2025, 12, 15), 3, 4 },
                    { 40, new DateTime(2025, 12, 16), 4, 5 },
                    { 41, new DateTime(2025, 12, 18), 5, 6 },
                    { 42, new DateTime(2025, 12, 23), 6, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}