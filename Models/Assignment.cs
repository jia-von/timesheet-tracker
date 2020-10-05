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
    }
}
