using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Timesheet_Tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectControllerAPI : ControllerBase
    {
        [HttpPost("Create")]
        public ActionResult CreateProject_Post(string projectName, DateTime dueDate, int employeeID)
        {
            ActionResult response;

            try
            {
                int newID = new ProjectController().CreateProject(projectName, dueDate, employeeID);
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}
