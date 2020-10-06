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

                entity.HasData(new Person() { ID = -1, Username = "admin", Email = "email@example.com", FirstName = "Jane", LastName = "Doe", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = DateTime.Today},
                    new Person() { ID = -2, Username = "admintwo", Email = "emailtwo@example.com", FirstName = "Jack", LastName = "Black", PasswordHash = "admin", PasswordSalt = "admin", DateCreated = DateTime.Today }
                    );
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PersonID).HasName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasOne(child => child.Person).WithOne(parent => parent.Employee).HasForeignKey<Employee>(child => child.PersonID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasData(new Employee() { ID = -1, Instructor = true, PersonID = -1 },
                    new Employee() { ID = -2, Instructor = false, Cohort = 4.1F, PersonID = -2 });
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.EmployeeID).HasName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.HasOne(child => child.Employee).WithMany(parent => parent.Projects).HasForeignKey(child => child.EmployeeID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Project) + "_" + nameof(Employee));
                entity.Property(e => e.ProjectName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.HasData(new Project() { ProjectName = "Entity Framework MVC", ID = -1, DateCreated = DateTime.Today, DueDate = DateTime.Today, EmployeeID = -2 });
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
