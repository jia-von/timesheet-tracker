using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models.DTO
{
    public class PersonDTO
    {
        // This is a DTO (Data Transfer Object), it's basically a copy-cat of the EF model, but allows for data to be moved around without loading full relational objects into memory.
        // This template is modified from 4.1-ReactAPI @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Models
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Instructor { get; set; }
        public float Cohort { get; set; }
        public string Token { get; set; }
        public int EmployeeID { get; set;  }
        public List<string> Projects { get; set; }
    }
}
