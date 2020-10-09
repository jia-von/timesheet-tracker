using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Models.DTO
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public float? DesignHours { get; set; }
        public float? CodeReviewHours { get; set; }
        public float? TestingHours { get; set; }
        public float? DeliverablesHours { get; set; }
        public float? TotalHours { get; set; }
    }
}
