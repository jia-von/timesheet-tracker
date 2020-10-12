using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models.DTO
{
    public class EmployeeDTO
    {
        // This is a DTO (Data Transfer Object), it's basically a copy-cat of the EF model, but allows for data to be moved around without loading full relational objects into memory.
        // Employee ID
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Instructor { get; set; }
        public float Cohort { get; set; }
        public string Email { get; set; }

        // Based on archive
        public bool Archive { get; set; }
    }

}
