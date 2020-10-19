using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{   //Code below are boilerplate clodes obtained from TECHCareers-by-Manpower 4.1 MVC project under PersonContext.cs @link: // Template from Tutorial: 4.1-ReactAPI @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI
    public partial class TimesheetContext : DbContext
    {
        public TimesheetContext()
        {

        }

        public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
        {

        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=timesheet_tracker", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Email).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Role).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PasswordHash).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PasswordSalt).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Person() { ID = -1, Email = "groot@guardians.com", FirstName = "Groot", LastName = "Groot", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 06, 15), Archive = false},
                    new Person() { ID = -2, Email = "starlord@guardians.com", FirstName = "Star", LastName = "Lord", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 10), Role = "Instructor", Archive = false},
                    new Person() { ID = -3, Email = "gamora@guardians.com", FirstName = "Gamora", LastName = "Guardians", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 06, 15), Archive = false},
                    new Person() { ID = -4, Email = "rocketraccoon@guardians.com", FirstName = "Rocket", LastName = "Raccoon", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020,06, 15), Archive = false },
                    new Person() { ID = -5, Email = "drax@guardians.com", FirstName = "Drax", LastName = "Destroyer", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 06, 15), Archive = false},
                    new Person() { ID = -6, Email = "tonystark@avengers.com", FirstName = "Tony", LastName = "Stark", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 10), Role = "Instructor", Archive = true},
                    new Person() { ID = -7, Email = "steverogers@avengers.com", FirstName = "Steve", LastName = "Rogers", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 10), Role = "Instructor", Archive = false},
                    new Person() { ID = -8, Email = "hulk@avengers.com", FirstName = "Bruce", LastName = "Banner", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 15), Archive = true },
                    new Person() { ID = -9, Email = "thor@avengers.com", FirstName = "Thor", LastName = "Thor", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 15), Archive = true},
                    new Person() { ID = -10, Email = "blackwidow@avengers.com", FirstName = "Natasha", LastName = "Romanoff", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 15), Archive = true },
                    new Person() { ID = -11, Email = "hawkeye@avengers.com", FirstName = "Clint", LastName = "Barton", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = new DateTime(2020, 02, 15), Archive = true }
                    );
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PersonID).HasName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasOne(child => child.Person).WithOne(parent => parent.Employee).HasForeignKey<Employee>(child => child.PersonID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasData(
                    new Employee() { ID = -1, Instructor = true, PersonID = -2 },
                    new Employee() { ID = -2, Instructor = false, Cohort = 4.1F, PersonID = -1, Archive = false },
                    new Employee() { ID = -3, Instructor = false, Cohort = 4.1F, PersonID = -3, Archive = false },
                    new Employee() { ID = -4, Instructor = false, Cohort = 4.1F, PersonID = -4, Archive = false },
                    new Employee() { ID = -5, Instructor = false, Cohort = 4.1F, PersonID = -5, Archive = false },
                    new Employee() { ID = -6, Instructor = true, PersonID = -6, Archive = true },
                    new Employee() { ID = -7, Instructor = true, PersonID = -7, Archive = false },
                    new Employee() { ID = -8, Instructor = false, Cohort = 4.0F, PersonID = -8, Archive = true },
                    new Employee() { ID = -9, Instructor = false, Cohort = 4.0F, PersonID = -9, Archive = true },
                    new Employee() { ID = -10, Instructor = false, Cohort = 4.0F, PersonID = -10, Archive = true },
                    new Employee() { ID = -11, Instructor = false, Cohort = 4.0F, PersonID = -11, Archive = true }
                    );
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.EmployeeID).HasName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.HasOne(child => child.Employee).WithMany(parent => parent.Projects).HasForeignKey(child => child.EmployeeID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.Property(e => e.ProjectName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.HasData(
                    new Project() { ProjectName = "C# OOP Practice", ID = -1, DesignHours = 0.5F, DoingHours = 2F, CodeReviewHours = 1.25F, TestingHours = 0.50F, DeliverablesHours = 2F, DateCreated = new DateTime(2020, 09, 06), DueDate = new DateTime(2020, 09, 18), EmployeeID = -2 },
                    new Project() { ProjectName = "C# OOP Practice", ID = -2, DesignHours = 1.5F, DoingHours = 1F, CodeReviewHours = 1F, TestingHours = 1.50F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 09, 06), DueDate = new DateTime(2020, 09, 18), EmployeeID = -3 },
                    new Project() { ProjectName = "C# OOP Practice", ID = -3, DesignHours = 2.5F, DoingHours = 3F, CodeReviewHours = 2F, TestingHours = 1F, DeliverablesHours = 0.25F, DateCreated = new DateTime(2020, 09, 06), DueDate = new DateTime(2020, 09, 18), EmployeeID = -4 },
                    new Project() { ProjectName = "C# OOP Practice", ID = -4, DesignHours = 0.75F, DoingHours = 0.5F, CodeReviewHours = 3.25F, TestingHours = 0.75F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 09, 06), DueDate = new DateTime(2020, 09, 18), EmployeeID = -5 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -5, DesignHours = 0.5F, DoingHours = 2F, CodeReviewHours = 1.25F, TestingHours = 0.50F, DeliverablesHours = 2F, DateCreated = DateTime.Today, DueDate = DateTime.Today.AddDays(2), EmployeeID = -2 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -6, DesignHours = 1.5F, DoingHours = 1F, CodeReviewHours = 1F, TestingHours = 1.50F, DeliverablesHours = 1F, DateCreated = DateTime.Today, DueDate = DateTime.Today.AddDays(2), EmployeeID = -3 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -7, DesignHours = 2.5F, DoingHours = 3F, CodeReviewHours = 2F, TestingHours = 1F, DeliverablesHours = 0.25F, DateCreated = DateTime.Today, DueDate = DateTime.Today.AddDays(2), EmployeeID = -4 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -8, DesignHours = 0.75F, DoingHours = 0.5F, CodeReviewHours = 3.25F, TestingHours = 0.75F, DeliverablesHours = 1F, DateCreated = DateTime.Today, DueDate = DateTime.Today.AddDays(2), EmployeeID = -5 },
                    new Project() { ProjectName = "React Calculator Assignment", ID = -9, DesignHours = 0.5F, DoingHours = 2F, CodeReviewHours = 1.25F, TestingHours = 0.50F, DeliverablesHours = 2F, DateCreated = new DateTime(2020, 04, 06), DueDate = new DateTime(2020, 04, 08), EmployeeID = -8, DateArchive = new DateTime(2020, 06, 01) , Archive = true},
                    new Project() { ProjectName = "React Calculator Assignment", ID = -10, DesignHours = 1.5F, DoingHours = 1F, CodeReviewHours = 1F, TestingHours = 1.50F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 04, 06), DueDate = new DateTime(2020, 04, 08), EmployeeID = -9, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "React Calculator Assignment", ID = -11, DesignHours = 2.5F, DoingHours = 3F, CodeReviewHours = 2F, TestingHours = 1F, DeliverablesHours = 0.25F, DateCreated = new DateTime(2020, 04, 06), DueDate = new DateTime(2020, 04, 08), EmployeeID = -10, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "React Calculator Assignment", ID = -12, DesignHours = 0.75F, DoingHours = 0.5F, CodeReviewHours = 3.25F, TestingHours = 0.75F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 04, 06), DueDate = new DateTime(2020, 04, 08), EmployeeID = -11, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "Milestone 1", ID = -13, DesignHours = 0.5F, DoingHours = 2F, CodeReviewHours = 1.25F, TestingHours = 0.50F, DeliverablesHours = 2F, DateCreated = new DateTime(2020, 05, 06), DueDate = new DateTime(2020, 05, 08), EmployeeID = -8, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "Milestone 1", ID = -14, DesignHours = 1.5F, DoingHours = 1F, CodeReviewHours = 1F, TestingHours = 1.50F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 05, 06), DueDate = new DateTime(2020, 05, 08), EmployeeID = -9, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "Milestone 1", ID = -15, DesignHours = 2.5F, DoingHours = 3F, CodeReviewHours = 2F, TestingHours = 1F, DeliverablesHours = 0.25F, DateCreated = new DateTime(2020, 05, 06), DueDate = new DateTime(2020, 05, 08), EmployeeID = -10, DateArchive = new DateTime(2020, 06, 01), Archive = true },
                    new Project() { ProjectName = "Milestone 1", ID = -16, DesignHours = 0.75F, DoingHours = 0.5F, CodeReviewHours = 3.25F, TestingHours = 0.75F, DeliverablesHours = 1F, DateCreated = new DateTime(2020, 05, 06), DueDate = new DateTime(2020, 05, 08), EmployeeID = -11, DateArchive = new DateTime(2020, 06, 01), Archive = true }
                    );
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
