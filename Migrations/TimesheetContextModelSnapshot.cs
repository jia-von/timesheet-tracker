﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheet_Tracker.Models;

namespace Timesheet_Tracker.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    partial class TimesheetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Timesheet_Tracker.Models.Assignment", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnName("employee_id")
                        .HasColumnType("int(10)");

                    b.Property<int>("ProjectID")
                        .HasColumnName("project_id")
                        .HasColumnType("int(10)");

                    b.HasKey("EmployeeID", "ProjectID");

                    b.HasIndex("EmployeeID")
                        .HasName("FK_Assignment_Employee");

                    b.HasIndex("ProjectID")
                        .HasName("FK_Assignment_Project");

                    b.ToTable("assignment");

                    b.HasData(
                        new
                        {
                            EmployeeID = -1,
                            ProjectID = -1
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<float>("Cohort")
                        .HasColumnName("cohort")
                        .HasColumnType("float(2,1)");

                    b.Property<bool>("Instructor")
                        .HasColumnName("instructor")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PersonID")
                        .HasColumnName("person_id")
                        .HasColumnType("int(10)");

                    b.HasKey("ID");

                    b.HasIndex("PersonID")
                        .IsUnique()
                        .HasName("FK_Employee_Person");

                    b.ToTable("employee");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Cohort = 0f,
                            Instructor = true,
                            PersonID = -1
                        },
                        new
                        {
                            ID = -2,
                            Cohort = 4.1f,
                            Instructor = false,
                            PersonID = -2
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<DateTime?>("DateArchive")
                        .HasColumnName("date_archive")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateModifiedProfile")
                        .HasColumnName("date_modified_profile")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("PasswordSalt")
                        .HasColumnName("password_salt")
                        .HasColumnType("varchar(10)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            DateCreated = new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "email@example.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            PasswordHash = "admin",
                            PasswordSalt = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            ID = -2,
                            DateCreated = new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "emailtwo@example.com",
                            FirstName = "Jack",
                            LastName = "Black",
                            PasswordHash = "admin",
                            PasswordSalt = "admin",
                            Username = "admintwo"
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<float?>("CodeReviewHours")
                        .HasColumnName("code_review_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<DateTime?>("DateArchive")
                        .HasColumnName("date_archive")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnName("date_completed")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created")
                        .HasColumnType("date");

                    b.Property<float?>("DeliverablesHours")
                        .HasColumnName("deliverables_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<float?>("DesignHours")
                        .HasColumnName("design_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<float?>("DoingHours")
                        .HasColumnName("doing_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("due_date")
                        .HasColumnType("datetime");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnName("project_name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<float?>("TestingHours")
                        .HasColumnName("testing_hours")
                        .HasColumnType("float(6,2)");

                    b.HasKey("ID");

                    b.ToTable("project");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            DateCreated = new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            ProjectName = "Entity Framework MVC"
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Assignment", b =>
                {
                    b.HasOne("Timesheet_Tracker.Models.Employee", "Employee")
                        .WithMany("Assignments")
                        .HasForeignKey("EmployeeID")
                        .HasConstraintName("FK_Assignment_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timesheet_Tracker.Models.Project", "Project")
                        .WithMany("Assignments")
                        .HasForeignKey("ProjectID")
                        .HasConstraintName("FK_Assignment_Project")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Employee", b =>
                {
                    b.HasOne("Timesheet_Tracker.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("Timesheet_Tracker.Models.Employee", "PersonID")
                        .HasConstraintName("FK_Employee_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
