using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    [Table("assignment")]
    public partial class Assignment
    {
        // This initializes an empty list so we don't get null reference exceptions for our list.
        public Assignment()
        {
            // PhoneNumbers = new HashSet<PhoneNumber>(); example
        }

        [Key]
        // This is to describe unique id number related to person
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // Navigation properties are listed in the code block below, this code block belongs to one-to-many relationship between employeeID and assignment
        // FK_Employee_Assignment
        [Required]
        [Column("employee_id", TypeName = "int(10)")]
        public int EmployeeID { get; set; }
        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty(nameof(Models.Employee.Assignment))]
        public virtual ICollection<Employee> Employees { get; set; }

        // Navigation properties are listed in the code block below, this code block belong to one-to-many relationship between projectID and assignment
        // FK_Project_Assignment
        [Required]
        [Column("project_id", TypeName = "int(10)")]
        public int ProjectID { get; set; }
        [ForeignKey(nameof(ProjectID))]
        [InverseProperty(nameof(Models.Project.Assignment))]
        public virtual ICollection<Project> Projects { get; set; }



    }
}
