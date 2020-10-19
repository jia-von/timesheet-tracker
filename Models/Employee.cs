using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    [Table("employee")]
    public partial class Employee
    {
        // Template from Tutorial: 4.1-ReactAPI @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI
        // This initializes an empty list so we don't get null reference exceptions for our list.
        public Employee()
        {
            Projects = new HashSet<Project>();
        }
        [Key]

        // This is to describe unique id number related to person
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("instructor", TypeName = "tinyint(1)")]
        public bool Instructor { get; set; }

        [Column("cohort", TypeName = "float(2,1)")]
        public float Cohort { get; set; }

        // According to Complex Data Tutorial: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-3.1,
        // The code below will be identified as Navigation Properties which include foreign keys, etc...

        [Required]
        [Column("person_id", TypeName = "int(10)")]
        public int PersonID { get; set; }

        [Column("archive", TypeName = "tinyint(1)")]
        public bool Archive { get; set; }

        // This attribute specifies which database field is the foreign key. Typically in the child (many side of the 1-many).
        [ForeignKey(nameof(PersonID))]
        [InverseProperty(nameof(Models.Person.Employee))]
        public virtual Person Person { get; set; }

        // Creating and inverse property of employee to assignment
        [InverseProperty(nameof(Models.Project.Employee))]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
