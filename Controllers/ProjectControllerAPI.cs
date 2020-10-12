using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet_Tracker.Models.DTO;

namespace Timesheet_Tracker.Controllers
{
    [Route("Project")]
    [ApiController]
    public class ProjectControllerAPI : ControllerBase
    {
        // Anthying with "Student" returns student view only and only for their ID.
        // "string id" receive input of the student ID
        [HttpGet("Student/All")]
        public ActionResult<List<ProjectDTO>> GetProjectListForStudent(string id)
        {
            ActionResult<List<ProjectDTO>> response;
            id = id != null ? id.Trim().ToLower() : null;
            if(string.IsNullOrEmpty(id))
            {
                response = StatusCode(400, "The id cannot be empty.");
            }
            else
            if(!int.TryParse(id, out int employeeID))
            {
                response = StatusCode(400, "The id has to be in number format.");
            }
            else
            {
                try
                {
                    response = new ProjectController().GetProjectListForStudent(employeeID).ToList();
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }

            }
            return response;
        }
    }
}
