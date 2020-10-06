using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheet_Tracker.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
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
                    date_modified_profile = table.Column<DateTime>(type: "timestamp", nullable: true)
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
                    person_id = table.Column<int>(type: "int(10)", nullable: false)
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
                columns: new[] { "id", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt", "username" },
                values: new object[] { -1, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, "email@example.com", "Jane", "Doe", "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "date_archive", "date_created", "date_modified_profile", "email", "first_name", "last_name", "password_hash", "password_salt", "username" },
                values: new object[] { -2, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, "emailtwo@example.com", "Jack", "Black", "admin", "admin", "admintwo" });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "cohort", "instructor", "person_id" },
                values: new object[] { -1, 0f, true, -1 });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "cohort", "instructor", "person_id" },
                values: new object[] { -2, 4.1f, false, -2 });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "id", "code_review_hours", "date_archive", "date_completed", "date_created", "deliverables_hours", "design_hours", "doing_hours", "due_date", "employee_id", "project_name", "testing_hours" },
                values: new object[] { -1, null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), -2, "Entity Framework MVC", null });

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
