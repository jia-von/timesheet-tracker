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
        public virtual DbSet<Assignment> Assignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=timesheet_tracker", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Assignment is considered a associative table, many to many relationship setup
            // To define the models/entities within the associative table
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeID, e.ProjectID});

                entity.HasIndex(e => e.EmployeeID).HasName("FK_" + nameof(Assignment) + "_" + nameof(Employee));
                entity.HasOne<Employee>(e => e.Employee)
                .WithMany(parent => parent.Assignments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.EmployeeID)
                .HasConstraintName("FK_" + nameof(Assignment) + "_" + nameof(Employee));

                entity.HasIndex(e => e.ProjectID).HasName("FK_" + nameof(Assignment) + "_" + nameof(Project));
                entity.HasOne<Project>(e => e.Project)
                .WithMany(parent => parent.Assignments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.ProjectID)
                .HasConstraintName("FK_" + nameof(Assignment) + "_" + nameof(Project));

            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Username).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Email).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PersonID).HasName("FK_" + nameof(Employee) + "_" + nameof(Person));
                entity.HasOne(child => child.Person).WithOne(parent => parent.Employee).HasForeignKey<Employee>(child => child.PersonID).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_" + nameof(Employee) + "_" + nameof(Person));
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
