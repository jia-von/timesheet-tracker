using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{   //Code below are boilerplate clodes obtained from TECHCareers-by-Manpower 4.1 MVC project under PersonContext.cs
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
                entity.Property(e => e.Username).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Email).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PasswordHash).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PasswordSalt).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Person() { ID = -1, Username = "groot", Email = "groot@guardians.com", FirstName = "Groot", LastName = "Groot", PasswordHash = new byte[] { 1, 2, 3, 4 }, PasswordSalt = new byte[] { 1,2,3,4}, DateCreated = DateTime.Today},
                    new Person() { ID = -2, Username = "starlord", Email = "starlord@guardians.com", FirstName = "Star", LastName = "Lord", PasswordHash = new byte[] { 1, 2, 3, 4 }, PasswordSalt = new byte[] { 1, 2, 3, 4 }, DateCreated = DateTime.Today},
                    new Person() { ID = -3, Username = "gamora", Email = "gamora@guardians.com", FirstName = "Gamora", LastName = "Guardians", PasswordHash = new byte[] { 1, 2, 3, 4 }, PasswordSalt = new byte[] { 1, 2, 3, 4 }, DateCreated = DateTime.Today },
                    new Person() { ID = -4, Username = "rocketraccoon", Email = "rocketraccoon@guardians.com", FirstName = "Rocket", LastName = "Raccoon", PasswordHash = new byte[] { 1, 2, 3, 4 }, PasswordSalt = new byte[] { 1, 2, 3, 4 }, DateCreated = DateTime.Today },
                    new Person() { ID = -5, Username = "drax", Email = "drax@guardians.com", FirstName = "Drax", LastName = "Destroyer", PasswordHash = new byte[] { 1, 2, 3, 4 }, PasswordSalt = new byte[] { 1, 2, 3, 4 }, DateCreated = DateTime.Today }
                    );
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PersonID).HasName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasOne(child => child.Person).WithOne(parent => parent.Employee).HasForeignKey<Employee>(child => child.PersonID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasData(
                    new Employee() { ID = -1, Instructor = true, PersonID = -2 },
                    new Employee() { ID = -2, Instructor = false, Cohort = 4.1F, PersonID = -1 },
                    new Employee() { ID = -3, Instructor = false, Cohort = 4.1F, PersonID = -3 },
                    new Employee() { ID = -4, Instructor = false, Cohort = 4.1F, PersonID = -4 },
                    new Employee() { ID = -5, Instructor = false, Cohort = 4.1F, PersonID = -5 }
                    );
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.EmployeeID).HasName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.HasOne(child => child.Employee).WithMany(parent => parent.Projects).HasForeignKey(child => child.EmployeeID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.Property(e => e.ProjectName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.HasData(
                    new Project() { ProjectName = "C# OOP Practice", ID = -1, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -2 },
                    new Project() { ProjectName = "React To-Do Planning", ID = -2, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -2 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -3, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -3 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -7, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -2 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -8, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -4 },
                    new Project() { ProjectName = "PHP API Assignment", ID = -9, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -5 },
                    new Project() { ProjectName = "Hello World", ID = -4, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -3 },
                    new Project() { ProjectName = "Soft Skill Assignment", ID = -5, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -4 },
                    new Project() { ProjectName = "Capstone", ID = -6, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -5 }
                    );
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
