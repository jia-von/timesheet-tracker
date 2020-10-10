using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class RolePropertyToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "person",
                type: "varchar(20)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -5,
                column: "date_created",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -4,
                column: "date_created",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -3,
                column: "date_created",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -2,
                column: "date_created",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "date_created", "role" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), "instructor" });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "person");

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -5,
                column: "date_created",
                value: new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -4,
                column: "date_created",
                value: new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -3,
                column: "date_created",
                value: new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -2,
                column: "date_created",
                value: new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -1,
                column: "date_created",
                value: new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "date_created", "due_date" },
                values: new object[] { new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
