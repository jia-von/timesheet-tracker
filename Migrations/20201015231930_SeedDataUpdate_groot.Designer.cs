﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheet_Tracker.Models;

namespace Timesheet_Tracker.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    [Migration("20201015231930_SeedDataUpdate_groot")]
    partial class SeedDataUpdate_groot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        },
                        new
                        {
                            ID = -6,
                            Archive = true,
                            Cohort = 0f,
                            Instructor = true,
                            PersonID = -6
                        },
                        new
                        {
                            ID = -7,
                            Archive = false,
                            Cohort = 0f,
                            Instructor = true,
                            PersonID = -7
                        },
                        new
                        {
                            ID = -8,
                            Archive = true,
                            Cohort = 4f,
                            Instructor = false,
                            PersonID = -8
                        },
                        new
                        {
                            ID = -9,
                            Archive = true,
                            Cohort = 4f,
                            Instructor = false,
                            PersonID = -9
                        },
                        new
                        {
                            ID = -10,
                            Archive = true,
                            Cohort = 4f,
                            Instructor = false,
                            PersonID = -10
                        },
                        new
                        {
                            ID = -11,
                            Archive = true,
                            Cohort = 4f,
                            Instructor = false,
                            PersonID = -11
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
                        .HasColumnType("varchar(90)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("PasswordSalt")
                        .HasColumnName("password_salt")
                        .HasColumnType("varchar(10)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Role")
                        .HasColumnName("role")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Archive = false,
                            DateCreated = new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            DateCreated = new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "starlord@guardians.com",
                            FirstName = "Star",
                            LastName = "Lord",
                            PasswordHash = "admin",
                            PasswordSalt = "admin",
                            Role = "Instructor"
                        },
                        new
                        {
                            ID = -3,
                            Archive = false,
                            DateCreated = new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            DateCreated = new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            DateCreated = new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "drax@guardians.com",
                            FirstName = "Drax",
                            LastName = "Destroyer",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -6,
                            Archive = true,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonystark@avengers.com",
                            FirstName = "Tony",
                            LastName = "Stark",
                            PasswordHash = "admin",
                            PasswordSalt = "admin",
                            Role = "Instructor"
                        },
                        new
                        {
                            ID = -7,
                            Archive = false,
                            DateCreated = new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "steverogers@avengers.com",
                            FirstName = "Steve",
                            LastName = "Rogers",
                            PasswordHash = "admin",
                            PasswordSalt = "admin",
                            Role = "Instructor"
                        },
                        new
                        {
                            ID = -8,
                            Archive = true,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hulk@avengers.com",
                            FirstName = "Bruce",
                            LastName = "Banner",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -9,
                            Archive = true,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "thor@avengers.com",
                            FirstName = "Thor",
                            LastName = "Thor",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -10,
                            Archive = true,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "blackwidow@avengers.com",
                            FirstName = "Natasha",
                            LastName = "Romanoff",
                            PasswordHash = "admin",
                            PasswordSalt = "admin"
                        },
                        new
                        {
                            ID = -11,
                            Archive = true,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hawkeye@avengers.com",
                            FirstName = "Clint",
                            LastName = "Barton",
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

                    b.Property<float>("CodeReviewHours")
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

                    b.Property<float>("DeliverablesHours")
                        .HasColumnName("deliverables_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<float>("DesignHours")
                        .HasColumnName("design_hours")
                        .HasColumnType("float(6,2)");

                    b.Property<float>("DoingHours")
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

                    b.Property<float>("TestingHours")
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
                            CodeReviewHours = 1.25f,
                            DateCreated = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 2f,
                            DesignHours = 0.5f,
                            DoingHours = 2f,
                            DueDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -2,
                            ProjectName = "C# OOP Practice",
                            TestingHours = 0.5f
                        },
                        new
                        {
                            ID = -2,
                            Archive = false,
                            CodeReviewHours = 1f,
                            DateCreated = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 1.5f,
                            DoingHours = 1f,
                            DueDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -3,
                            ProjectName = "C# OOP Practice",
                            TestingHours = 1.5f
                        },
                        new
                        {
                            ID = -3,
                            Archive = false,
                            CodeReviewHours = 2f,
                            DateCreated = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 0.25f,
                            DesignHours = 2.5f,
                            DoingHours = 3f,
                            DueDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -4,
                            ProjectName = "C# OOP Practice",
                            TestingHours = 1f
                        },
                        new
                        {
                            ID = -4,
                            Archive = false,
                            CodeReviewHours = 3.25f,
                            DateCreated = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 0.75f,
                            DoingHours = 0.5f,
                            DueDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -5,
                            ProjectName = "C# OOP Practice",
                            TestingHours = 0.75f
                        },
                        new
                        {
                            ID = -5,
                            Archive = false,
                            CodeReviewHours = 1.25f,
                            DateCreated = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DeliverablesHours = 2f,
                            DesignHours = 0.5f,
                            DoingHours = 2f,
                            DueDate = new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -2,
                            ProjectName = "PHP API Assignment",
                            TestingHours = 0.5f
                        },
                        new
                        {
                            ID = -6,
                            Archive = false,
                            CodeReviewHours = 1f,
                            DateCreated = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DeliverablesHours = 1f,
                            DesignHours = 1.5f,
                            DoingHours = 1f,
                            DueDate = new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -3,
                            ProjectName = "PHP API Assignment",
                            TestingHours = 1.5f
                        },
                        new
                        {
                            ID = -7,
                            Archive = false,
                            CodeReviewHours = 2f,
                            DateCreated = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DeliverablesHours = 0.25f,
                            DesignHours = 2.5f,
                            DoingHours = 3f,
                            DueDate = new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -4,
                            ProjectName = "PHP API Assignment",
                            TestingHours = 1f
                        },
                        new
                        {
                            ID = -8,
                            Archive = false,
                            CodeReviewHours = 3.25f,
                            DateCreated = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DeliverablesHours = 1f,
                            DesignHours = 0.75f,
                            DoingHours = 0.5f,
                            DueDate = new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeID = -5,
                            ProjectName = "PHP API Assignment",
                            TestingHours = 0.75f
                        },
                        new
                        {
                            ID = -9,
                            Archive = true,
                            CodeReviewHours = 1.25f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 2f,
                            DesignHours = 0.5f,
                            DoingHours = 2f,
                            DueDate = new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -8,
                            ProjectName = "React Calculator Assignment",
                            TestingHours = 0.5f
                        },
                        new
                        {
                            ID = -10,
                            Archive = true,
                            CodeReviewHours = 1f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 1.5f,
                            DoingHours = 1f,
                            DueDate = new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -9,
                            ProjectName = "React Calculator Assignment",
                            TestingHours = 1.5f
                        },
                        new
                        {
                            ID = -11,
                            Archive = true,
                            CodeReviewHours = 2f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 0.25f,
                            DesignHours = 2.5f,
                            DoingHours = 3f,
                            DueDate = new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -10,
                            ProjectName = "React Calculator Assignment",
                            TestingHours = 1f
                        },
                        new
                        {
                            ID = -12,
                            Archive = true,
                            CodeReviewHours = 3.25f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 0.75f,
                            DoingHours = 0.5f,
                            DueDate = new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -11,
                            ProjectName = "React Calculator Assignment",
                            TestingHours = 0.75f
                        },
                        new
                        {
                            ID = -13,
                            Archive = true,
                            CodeReviewHours = 1.25f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 2f,
                            DesignHours = 0.5f,
                            DoingHours = 2f,
                            DueDate = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -8,
                            ProjectName = "Milestone 1",
                            TestingHours = 0.5f
                        },
                        new
                        {
                            ID = -14,
                            Archive = true,
                            CodeReviewHours = 1f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 1.5f,
                            DoingHours = 1f,
                            DueDate = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -9,
                            ProjectName = "Milestone 1",
                            TestingHours = 1.5f
                        },
                        new
                        {
                            ID = -15,
                            Archive = true,
                            CodeReviewHours = 2f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 0.25f,
                            DesignHours = 2.5f,
                            DoingHours = 3f,
                            DueDate = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -10,
                            ProjectName = "Milestone 1",
                            TestingHours = 1f
                        },
                        new
                        {
                            ID = -16,
                            Archive = true,
                            CodeReviewHours = 3.25f,
                            DateArchive = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliverablesHours = 1f,
                            DesignHours = 0.75f,
                            DoingHours = 0.5f,
                            DueDate = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeID = -11,
                            ProjectName = "Milestone 1",
                            TestingHours = 0.75f
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
