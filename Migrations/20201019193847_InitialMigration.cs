using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class InitialMigration : Migration
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
                    password_hash = table.Column<string>(type: "varchar(90)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    password_salt = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    role = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
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
                    design_hours = table.Column<float>(type: "float(6,2)", nullable: false),
                    doing_hours = table.Column<float>(type: "float(6,2)", nullable: false),
                    code_review_hours = table.Column<float>(type: "float(6,2)", nullable: false),
                    testing_hours = table.Column<float>(type: "float(6,2)", nullable: false),
                    deliverables_hours = table.Column<float>(type: "float(6,2)", nullable: false),
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
                columns: new[] { "id", "archive", "date_created", "email", "first_name", "last_name", "password_hash", "password_salt", "role" },
                values: new object[,]
                {
                    { -1, false, new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "groot@guardians.com", "Groot", "Groot", "admin", "admin", null },
                    { -2, false, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "starlord@guardians.com", "Star", "Lord", "admin", "admin", "Instructor" },
                    { -3, false, new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamora@guardians.com", "Gamora", "Guardians", "admin", "admin", null },
                    { -4, false, new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "rocketraccoon@guardians.com", "Rocket", "Raccoon", "admin", "admin", null },
                    { -5, false, new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "drax@guardians.com", "Drax", "Destroyer", "admin", "admin", null },
                    { -6, true, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "tonystark@avengers.com", "Tony", "Stark", "admin", "admin", "Instructor" },
                    { -7, false, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "steverogers@avengers.com", "Steve", "Rogers", "admin", "admin", "Instructor" },
                    { -8, true, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "hulk@avengers.com", "Bruce", "Banner", "admin", "admin", null },
                    { -9, true, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "thor@avengers.com", "Thor", "Thor", "admin", "admin", null },
                    { -10, true, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "blackwidow@avengers.com", "Natasha", "Romanoff", "admin", "admin", null },
                    { -11, true, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "hawkeye@avengers.com", "Clint", "Barton", "admin", "admin", null }
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
                    { -5, false, 4.1f, false, -5 },
                    { -6, true, 0f, true, -6 },
                    { -7, false, 0f, true, -7 },
                    { -8, true, 4f, false, -8 },
                    { -9, true, 4f, false, -9 },
                    { -10, true, 4f, false, -10 },
                    { -11, true, 4f, false, -11 }
                });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "archive", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[,]
                {
                    { -1, false, 1.25f, null, null, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, "C# OOP Practice", 0.5f },
                    { -5, false, 1.25f, null, null, new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 2f, 0.5f, 2f, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), -2, "PHP API Assignment", 0.5f },
                    { -2, false, 1f, null, null, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -3, "C# OOP Practice", 1.5f },
                    { -6, false, 1f, null, null, new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 1f, 1.5f, 1f, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), -3, "PHP API Assignment", 1.5f },
                    { -3, false, 2f, null, null, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -4, "C# OOP Practice", 1f },
                    { -7, false, 2f, null, null, new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 0.25f, 2.5f, 3f, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), -4, "PHP API Assignment", 1f },
                    { -4, false, 3.25f, null, null, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -5, "C# OOP Practice", 0.75f },
                    { -8, false, 3.25f, null, null, new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 1f, 0.75f, 0.5f, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), -5, "PHP API Assignment", 0.75f },
                    { -9, true, 1.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -8, "React Calculator Assignment", 0.5f },
                    { -13, true, 1.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0.5f, 2f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -8, "Milestone 1", 0.5f },
                    { -10, true, 1f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, "React Calculator Assignment", 1.5f },
                    { -14, true, 1f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1.5f, 1f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, "Milestone 1", 1.5f },
                    { -11, true, 2f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, "React Calculator Assignment", 1f },
                    { -15, true, 2f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.25f, 2.5f, 3f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -10, "Milestone 1", 1f },
                    { -12, true, 3.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, "React Calculator Assignment", 0.75f },
                    { -16, true, 3.25f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0.75f, 0.5f, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, "Milestone 1", 0.75f }
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
