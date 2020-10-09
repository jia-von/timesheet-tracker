using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    [Table("person")]
    public partial class Person
    {
        [Key]
        // This is to describe unique id number related to person
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column("password_hash", TypeName = "varchar(90)")]
        public string PasswordHash { get; set; }

        [Column("password_salt", TypeName = "varchar(10)")]
        public string PasswordSalt { get; set; }
        [Required]
        [Column("date_created", TypeName = "date")]
        public DateTime DateCreated { get; set; }

        // can be null as we do not know when the user will delete/archive their account in the future
        [Column("date_archive", TypeName = "date")]
        public DateTime? DateArchive { get; set; }

        // can be null as we do not know when the user will change their account in the future
        [Column("date_modified_profile", TypeName = "timestamp")]
        public DateTime? DateModifiedProfile { get; set; }

        [Column("archive", TypeName = "tinyint(1)")]
        public bool Archive { get; set; }


        // Below this is the navigation property of one-to-one relationship, required and not null
        [InverseProperty(nameof(Models.Employee.Person))]
        public virtual Employee Employee { get; set; }
    }
}
