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

        // Design, doing, code review, testing, deliverable hours are all nullable because it can be edited by the person
        // https://dev.mysql.com/doc/refman/5.7/en/precision-math-decimal-characteristics.html decimal datatype for MySQL
        // https://dev.mysql.com/doc/refman/5.7/en/floating-point-types.html floating point value with MySQL
        // MySQL Float(6,2) will be like 9999.99, cause hours can be in the thousands like 2000 man hours
        // Float properties are nullable as we do not know how many hours to start with.
        [Column("design_hours", TypeName = "float(6,2)")]
        public float? DesignHours { get; set; }

        [Column("doing_hours", TypeName = "float(6,2)")]
        public float? DoingHours { get; set; }

        [Column("code_review_hours", TypeName = "float(6,2)")]
        public float? CodeReviewHours { get; set; }

        [Column("testing_hours", TypeName = "float(6,2)")]
        public float? TestingHours { get; set; }

        [Column("deliverables_hours", TypeName = "float(6,2)")]
        public float? DeliverablesHours { get; set; }

        // navigation FK_Project_Assignment
        [InverseProperty(nameof(Models.Assignment.Projects))]
        public virtual Assignment Assignment { get; set; }



    }
}
