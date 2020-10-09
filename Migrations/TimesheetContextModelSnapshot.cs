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

            modelBuilder.Entity("Timesheet_Tracker.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<bool>("Archive")
                        .HasColumnName("archive")
                        .HasColumnType("tinyint(1)");

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
                            Archive = false,
                            Cohort = 0f,
                            Instructor = true,
                            PersonID = -2
                        },
                        new
                        {
                            ID = -2,
                            Archive = false,
                            Cohort = 4.1f,
                            Instructor = false,
                            PersonID = -1
                        },
                        new
                        {
                            ID = -3,
                            Archive = false,
                            Cohort = 4.1f,
                            Instructor = false,
                            PersonID = -3
                        },
                        new
                        {
                            ID = -4,
                            Archive = false,
                            Cohort = 4.1f,
                            Instructor = false,
                            PersonID = -4
                        },
                        new
                        {
                            ID = -5,
                            Archive = false,
                            Cohort = 4.1f,
                            Instructor = false,
                            PersonID = -5
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<bool>("Archive")
                        .HasColumnName("archive")
                        .HasColumnType("tinyint(1)");

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

                    b.HasKey("ID");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "groot@guardians.com",
                            FirstName = "Groot",
                            LastName = "Groot",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -2,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "starlord@guardians.com",
                            FirstName = "Star",
                            LastName = "Lord",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -3,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "gamora@guardians.com",
                            FirstName = "Gamora",
                            LastName = "Guardians",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -4,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "rocketraccoon@guardians.com",
                            FirstName = "Rocket",
                            LastName = "Raccoon",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -5,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "drax@guardians.com",
                            FirstName = "Drax",
                            LastName = "Destroyer",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        });
                });

            modelBuilder.Entity("Timesheet_Tracker.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<bool>("Archive")
                        .HasColumnName("archive")
                        .HasColumnType("tinyint(1)");

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

                    b.Property<int>("EmployeeID")
                        .HasColumnName("employee_id")
                        .HasColumnType("int(10)");

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

                    b.HasIndex("EmployeeID")
                        .HasName("FK_Project_Employee");

                    b.ToTable("project");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -2,
                            ProjectName = "C# OOP Practice"
                        },
                        new
                        {
                            ID = -2,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -2,
                            ProjectName = "React To-Do Planning"
                        },
                        new
                        {
                            ID = -3,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -3,
                            ProjectName = "PHP API Assignment"
                        },
                        new
                        {
                            ID = -7,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -2,
                            ProjectName = "PHP API Assignment"
                        },
                        new
                        {
                            ID = -8,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -4,
                            ProjectName = "PHP API Assignment"
                        },
                        new
                        {
                            ID = -9,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -5,
                            ProjectName = "PHP API Assignment"
                        },
                        new
                        {
                            ID = -4,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -3,
                            ProjectName = "Hello World"
                        },
                        new
                        {
                            ID = -5,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -4,
                            ProjectName = "Soft Skill Assignment"
                        },
                        new
                        {
                            ID = -6,
                            Archive = false,
                            DateCreated = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            DueDate = new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -5,
                            ProjectName = "Capstone"
                        });
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

            modelBuilder.Entity("Timesheet_Tracker.Models.Project", b =>
                {
                    b.HasOne("Timesheet_Tracker.Models.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeID")
                        .HasConstraintName("FK_Project_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
