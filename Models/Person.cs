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
        // This initializes an empty list so we don't get null reference exceptions for our list.
        public Person()
        {
            // PhoneNumbers = new HashSet<PhoneNumber>(); example
        }

        [Key]
        // This is to describe unique id number related to person
        [Column("id", TypeName = "int(10)")]

        // Auto generate unique id number
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("first_name",TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("date_created", TypeName = "date")]
        public DateTime DateCreated { get; set; }

        // can be null as we do not know when the user will delete/archive their account in the future
        [Column("date_archive", TypeName = "date")]
        public DateTime? DateArchive { get; set; }

        // can be null as we do not know when the user will change their account in the future
        [Column("date_modified_profile", TypeName = "timestamp")]
        public DateTime? DateModifiedProfile { get; set; }

        // Password hashing to be added at later point, 


        // Below this is the navigation property of one-to-one relationship, required and not null
        [InverseProperty(nameof(Models.Employee.Person))]
        public virtual Employee Employee { get; set; }
    }
}
