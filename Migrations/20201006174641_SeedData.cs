using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { -7, null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), -2, "PHP API Assignment", null });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { -8, null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), -4, "PHP API Assignment", null });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { -9, null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), -5, "PHP API Assignment", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -7);
        }
    }
}
