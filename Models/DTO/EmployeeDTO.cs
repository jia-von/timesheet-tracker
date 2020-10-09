using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models.DTO
{
    public class EmployeeDTO
    {
        // This is a DTO (Data Transfer Object), it's basically a copy-cat of the EF model, but allows for data to be moved around without loading full relational objects into memory.
        public int ID { get; set; }
        public string FullName { get; set; }
        public bool Instructor { get; set; }
        public float Cohort { get; set; }
    }

}
