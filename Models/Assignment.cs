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
        // Solution for many-to-many relationship: https://stackoverflow.com/questions/19342908/how-to-create-a-many-to-many-mapping-in-entity-framework

        [Key]
        // This is to describe unique id number related to person
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // FK_Project_Assignment
        [Required]
        [Column("project_id", TypeName = "int(10)")]
        public int ProjectID { get; set; }

        // FK_Employee_Assignment
        [Required]
        [Column("employee_id", TypeName = "int(10)")]
        public int EmployeeID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty(nameof(Models.Employee.Assignments))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(ProjectID))]
        [InverseProperty(nameof(Models.Project.Assignments))]
        public virtual Project Project { get; set; }
    }
}
