using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    [Table("project")]
    public partial class Project
    {
        // This initializes an empty list so we don't get null reference exceptions for our list.
        [Key]
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("project_name", TypeName = "varchar(50)")]
        public string ProjectName { get; set; }

        // Due date has a time component in it, therefore the properties require date, eg. Due at 9:00 am
        [Required]
        [Column("due_date", TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [Required]
        [Column("date_created", TypeName = "date")]
        public DateTime DateCreated { get; set; }

        [Column("date_completed", TypeName = "datetime")]
        public DateTime? DateCompleted { get; set; }

        [Column("date_archive", TypeName = "date")]
        public DateTime? DateArchive { get; set; }

        [Required]
        [Column("design_hours", TypeName = "float(6,2)")]
        public float DesignHours { get; set; }

        [Required]
        [Column("doing_hours", TypeName = "float(6,2)")]
        public float DoingHours { get; set; }

        [Required]
        [Column("code_review_hours", TypeName = "float(6,2)")]
        public float CodeReviewHours { get; set; }

        [Required]
        [Column("testing_hours", TypeName = "float(6,2)")]
        public float TestingHours { get; set; }

        [Required]
        [Column("deliverables_hours", TypeName = "float(6,2)")]
        public float DeliverablesHours { get; set; }

        [Required]
        [Column("archive", TypeName = "tinyint(1)")]
        public bool Archive { get; set; }

        // navigation FK_Project-Employee
        [Required]
        [Column("employee_id", TypeName = "int(10)")]
        public int EmployeeID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty(nameof(Models.Employee.Projects))]
        public virtual Employee Employee { get; set; }


    }
}
