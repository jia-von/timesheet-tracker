using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class SecondaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    first_name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    password_hash = table.Column<string>(type: "varchar(40)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    password_salt = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_archive = table.Column<DateTime>(type: "date", nullable: true),
                    date_modified_profile = table.Column<DateTime>(type: "timestamp", nullable: true),
                    archive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    instructor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cohort = table.Column<float>(type: "float(2,1)", nullable: false),
                    person_id = table.Column<int>(type: "int(10)", nullable: false),
                    archive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Person",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_completed = table.Column<DateTime>(type: "datetime", nullable: true),
                    date_archive = table.Column<DateTime>(type: "date", nullable: true),
                    design_hours = table.Column<float>(type: "float(6,2)", nullable: true),
                    doing_hours = table.Column<float>(type: "float(6,2)", nullable: true),
                    code_review_hours = table.Column<float>(type: "float(6,2)", nullable: true),
                    testing_hours = table.Column<float>(type: "float(6,2)", nullable: true),
                    deliverables_hours = table.Column<float>(type: "float(6,2)", nullable: true),
                    archive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    employee_id = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                    table.ForeignKey(
                        name: "FK_Project_Employee",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "archive", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt" },
                values: new object[,]
                {
                    { -1, false, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "groot@guardians.com", "Groot", "Groot", "admin", "admin" },
                    { -2, false, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "starlord@guardians.com", "Star", "Lord", "admin", "admin" },
                    { -3, false, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "gamora@guardians.com", "Gamora", "Guardians", "admin", "admin" },
                    { -4, false, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "rocketraccoon@guardians.com", "Rocket", "Raccoon", "admin", "admin" },
                    { -5, false, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "drax@guardians.com", "Drax", "Destroyer", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "archive", "cohort", "instructor", "person_id" },
                values: new object[,]
                {
                    { -2, false, 4.1f, false, -1 },
                    { -1, false, 0f, true, -2 },
                    { -3, false, 4.1f, false, -3 },
                    { -4, false, 4.1f, false, -4 },
                    { -5, false, 4.1f, false, -5 }
                });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "archive", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[,]
                {
                    { -1, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -2, "C# OOP Practice", null },
                    { -2, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -2, "React To-Do Planning", null },
                    { -7, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -2, "PHP API Assignment", null },
                    { -3, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -3, "PHP API Assignment", null },
                    { -4, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -3, "Hello World", null },
                    { -8, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -4, "PHP API Assignment", null },
                    { -5, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -4, "Soft Skill Assignment", null },
                    { -9, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -5, "PHP API Assignment", null },
                    { -6, false, null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local), -5, "Capstone", null }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Employee_Person",
                table: "employee",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Project_Employee",
                table: "project",
                column: "employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
