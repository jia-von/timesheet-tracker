using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    // this specifies all the allowed roles for the timesheet app
    // roles can be added to users by calling Roles.DESIRED_ROLE
    public static class Roles
    {
        public const string Instructor = "Instructor";
        public const string Student = "Student";
    }
}
