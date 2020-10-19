using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models
{
    // Referenced to ASP.NET Core 3.1 - Simple API for Authentication, Registration and User Management @link: https://jasonwatmore.com/post/2019/10/14/aspnet-core-3-simple-api-for-authentication-registration-and-user-management
    // this specifies all the allowed roles for the timesheet app
    // roles can be added to users by calling Roles.DESIRED_ROLE
    public static class Roles
    {
        public const string Instructor = "Instructor";
        public const string Student = "Student";
    }
}
