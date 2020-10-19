using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class SeedDataUpdate_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -5,
                column: "date_created",
                value: new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -4,
                column: "date_created",
                value: new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -3,
                column: "date_created",
                value: new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "date_created", "role" },
                values: new object[] { new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instructor" });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -1,
                column: "date_created",
                value: new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "archive", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt", "role" },
                values: new object[,]
                {
                    { -6, true, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tonystark@avengers.com", "Tony", "Stark", "admin", "admin", "Instructor" },
                    { -10, true, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "blackwidow@avengers.com", "Natasha", "Romanoff", "admin", "admin", null },
                    { -9, true, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "thor@avengers.com", "Thor", "Thor", "admin", "admin", null },
                    { -8, true, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hulk@avengers.com", "Bruce", "Banner", "admin", "admin", null },
                    { -7, false, null, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "steverogers@avengers.com", "Steve", "Rogers", "admin", "admin", "Instructor" },
                    { -11, true, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hawkeye@avengers.com", "Clint", "Barton", "admin", "admin", null }
                });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "testing_hours" },
                values: new object[] { 3.25f, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 1f, 0.75f, 0.5f, new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), -5, 0.75f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "testing_hours" },
                values: new object[] { 2f, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 0.25f, 2.5f, 3f, new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), -4, 1f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 1f, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 1f, 1.5f, 1f, new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), -3, "PHP API Assignment", 1.5f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 1.25f, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 2f, 0.5f, 2f, new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), -2, "PHP API Assignment", 0.5f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 3.25f, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -5, "C# OOP Practice", 0.75f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 2f, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -4, "C# OOP Practice", 1f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 1f, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -3, "C# OOP Practice", 1.5f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 1.25f, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.5f });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "archive", "cohort", "instructor", "person_id" },
                values: new object[,]
                {
                    { -6, true, 0f, true, -6 },
                    { -7, false, 0f, true, -7 },
                    { -8, true, 4f, false, -8 },
                    { -9, true, 4f, false, -9 },
                    { -10, true, 4f, false, -10 },
                    { -11, true, 4f, false, -11 }
                });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "archive", "code_review_hours", "date_archive", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { true, 1.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -8, "React Calculator Assignment", 0.5f });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "archive", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[,]
                {
                    { -13, true, 1.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -8, "Milestone 1", 0.5f },
                    { -10, true, 1f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, "React Calculator Assignment", 1.5f },
                    { -14, true, 1f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, "Milestone 1", 1.5f },
                    { -11, true, 2f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, "React Calculator Assignment", 1f },
                    { -15, true, 2f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, "Milestone 1", 1f },
                    { -12, true, 3.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, "React Calculator Assignment", 0.75f },
                    { -16, true, 3.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, "Milestone 1", 0.75f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -5,
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -4,
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -3,
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "date_created", "role" },
                values: new object[] { new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -1,
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -4, 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -2, 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -5, "Capstone", 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -4, "Soft Skill Assignment", 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -3, "Hello World", 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -3, "PHP API Assignment", 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -2, "React To-Do Planning", 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "archive", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { -9, false, 0f, null, null, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), -5, "PHP API Assignment", 0f });
        }
    }
}
