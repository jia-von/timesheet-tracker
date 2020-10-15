using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class HoursChangedToNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "testing_hours",
                table: "project",
                type: "float(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "doing_hours",
                table: "project",
                type: "float(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "design_hours",
                table: "project",
                type: "float(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "deliverables_hours",
                table: "project",
                type: "float(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "code_review_hours",
                table: "project",
                type: "float(6,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6,2)",
                oldNullable: true);

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
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: -1,
                column: "date_created",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f, 0f, 0f, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 0f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "testing_hours",
                table: "project",
                type: "float(6,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "doing_hours",
                table: "project",
                type: "float(6,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "design_hours",
                table: "project",
                type: "float(6,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "deliverables_hours",
                table: "project",
                type: "float(6,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "code_review_hours",
                table: "project",
                type: "float(6,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float(6,2)");

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
                column: "date_created",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "project",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "code_review_hours", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "testing_hours" },
                values: new object[] { null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null });
        }
    }
}
