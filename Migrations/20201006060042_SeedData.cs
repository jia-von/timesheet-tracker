using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password_salt",
                table: "person",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "person",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt", "username" },
                values: new object[] { -1, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, "email@example.com", "Jane", "Doe", "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt", "username" },
                values: new object[] { -2, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, "emailtwo@example.com", "Jack", "Black", "admin", "admin", "admintwo" });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "project_name", "testing_hours" },
                values: new object[] { -1, null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), "Entity Framework MVC", null });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "cohort", "instructor", "person_id" },
                values: new object[] { -1, 0f, true, -1 });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "cohort", "instructor", "person_id" },
                values: new object[] { -2, 4.1f, false, -2 });

            migrationBuilder.InsertData(
                table: "assignment",
                columns: new[] { "employee_id", "project_id" },
                values: new object[] { -1, -1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "assignment",
                keyColumns: new[] { "employee_id", "project_id" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "project",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "password_salt",
                table: "person",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "person",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");
        }
    }
}
