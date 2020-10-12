using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Timesheet_Tracker.Models.DTO;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    [Route("Project")]
    [ApiController]
    public class ProjectControllerAPI : ControllerBase
    {
        // Anthying with "Student" returns student view only and only for their ID.
        // "string id" receive input of the student ID
        [HttpGet("Student")]
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

        // show individual project that is associated with the employee ID
        [HttpGet("Student/Project")]
        public ActionResult<ProjectDTO> GetProjectForStudent(string projectID, string employeeID)
        {
            ActionResult<ProjectDTO> response;
            ValidationExceptions exceptions = new ValidationExceptions();
            projectID = projectID != null ? projectID.Trim().ToLower() : null;
            employeeID = employeeID != null ? employeeID.Trim().ToLower() : null;

            if(string.IsNullOrEmpty(projectID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The project must have and ID"));

            }else if(!int.TryParse(projectID, out int _projectID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The project ID must be in number format"));
            }
            
            if(string.IsNullOrEmpty(employeeID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The employee must have an ID. "));
            }else
            if(!int.TryParse(employeeID, out int _employeeID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The employee ID must be in number format. "));
            }
            
            if(exceptions.SubExceptions.Count> 0)
            {
                response = UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
            }
            else
            {
                try
                {
                    response = new ProjectController().GetProjectForStudent(int.Parse(projectID), int.Parse(employeeID));
                }
                catch (ValidationExceptions)
                {
                    response = UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
                }
            }

            return response;
        }

        [HttpPatch("Student/Update")]
        public ActionResult<ProjectDTO> UpdateProject(string projectID, string design, string doing, string codeReview, string testing, string deliverables)
        {
            ActionResult<ProjectDTO> response;
            ValidationExceptions exceptions = new ValidationExceptions();

            projectID = projectID != null ? projectID.Trim().ToLower() : null;
            design = design != null ? design.Trim().ToLower() : "0";
            doing = doing != null ? doing.Trim().ToLower() : "0";
            codeReview = codeReview != null ? codeReview.Trim().ToLower() : "0";
            testing = testing != null ? testing.Trim().ToLower() : "0";
            deliverables = deliverables!= null ? deliverables.Trim().ToLower() : "0";

            if(string.IsNullOrEmpty(projectID))
            {
                response = StatusCode(400, "Project must have ID in order to update the hours.");
            }
            else
            if(!int.TryParse(projectID, out int _projectID))
            {
                response = StatusCode(400, "Project ID must be in number format.");
            }
            else
            {
                if(!float.TryParse(design, out float _design))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }else
                if(_design % 0.25 != 0)
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be quarterly format of 0.25, 0.50, 0.75, or 1.00 and above."));
                }

                if (!float.TryParse(doing, out float _doing))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }
                else
                if (_doing % 0.25 != 0)
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be quarterly format of 0.25, 0.50, 0.75, or 1.00 and above."));
                }

                if (!float.TryParse(codeReview, out float _codeReview))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }
                else
                if (_codeReview % 0.25 != 0)
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be quaterly format of 0.25, 0.50, 0.75, or 1.00 and above."));
                }

                if (!float.TryParse(testing, out float _testing))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }
                else
                if (_testing % 0.25 != 0)
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be quaterly format of 0.25, 0.50, 0.75, or 1.00 and above."));
                }

                if (!float.TryParse(deliverables, out float _deliverables))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }
                else
                if (_deliverables % 0.25 != 0)
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be quarterly format of 0.25, 0.50, 0.75, or 1.00 and above."));
                }

                if(exceptions.SubExceptions.Count>0)
                {
                    response = UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
                }
                else
                {
                    new ProjectController().UpdateHours(int.Parse(projectID), float.Parse(design), float.Parse(doing), float.Parse(codeReview), float.Parse(testing), float.Parse(deliverables));
                    response = StatusCode(200, "Hours updated.");
                    // TODO need to re-direct somewhere...... 
                }
            }
            return response;
        }

        [HttpPatch("Student/Archive")]
        public ActionResult Archive(string projectID)
        {
            ActionResult response;
            projectID = projectID != null ? projectID.Trim().ToLower() : null;
            
            if(string.IsNullOrEmpty(projectID))
            {
                response = StatusCode(400, "Please enter a project ID.");
            }
            else
            if(!int.TryParse(projectID, out int _projectID))
            {
                response = StatusCode(400, "The ID have to be a number format.");
            }
            else
            {
                try
                {
                    new ProjectController().Archive(_projectID);
                    response = StatusCode(200, "The project has been successfully archived.");
                }
                catch(Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }
            return response;
        }

        [HttpGet("Instructor")]
        // get a list of all the projects
        public ActionResult<List<ProjectDTO>> GetAllProjects()
        {
            return new ProjectController().GetAllProjects();
        }
    }
}
