using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    [Authorize]
    [Route("Project")]
    [ApiController]
    public class ProjectControllerAPI : ControllerBase
    {
        // This template is from 4.1-ReactAPI project @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Controllers
        [HttpGet("ID")]
        public ActionResult<ProjectDTO> GetProjectByID(string id)
        {
            ActionResult<ProjectDTO> response;
            id = id?.Trim().ToLower();
            if (string.IsNullOrEmpty(id))
            {
                response = StatusCode(400, "The id cannot be empty.");
            }
            else
            if (!int.TryParse(id, out int projectID))
            {
                response = StatusCode(400, "The id has to be in number format.");
            }
            else
            {
                try
                {
                    response = new ProjectController().GetAllProjects().Where(x => x.ID == projectID).SingleOrDefault();
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }

            }
            if (response == null)
            {
                return StatusCode(400, "The project was not found");
            }

            return response;
        }

        // Anthying with "Student" returns student view only and only for their ID.
        // "string id" receive input of the student ID
        [HttpGet("Student")]
        public ActionResult<List<ProjectDTO>> GetProjectListForStudent(string id)
        {
            ActionResult<List<ProjectDTO>> response;
            id = id != null ? id.Trim().ToLower() : null;
            if (string.IsNullOrEmpty(id))
            {
                response = StatusCode(400, "The id cannot be empty.");
            }
            else
            if (!int.TryParse(id, out int employeeID))
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
            deliverables = deliverables != null ? deliverables.Trim().ToLower() : "0";

            if (string.IsNullOrEmpty(projectID))
            {
                response = StatusCode(400, "Project must have ID in order to update the hours.");
            }
            else
            if (!int.TryParse(projectID, out int _projectID))
            {
                response = StatusCode(400, "Project ID must be in number format.");
            }
            else
            {
                if (!float.TryParse(design, out float _design))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Hours have to be number format. Example: 0.25."));
                }
                else
                if (_design % 0.25 != 0)
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

                if (exceptions.SubExceptions.Count > 0)
                {
                    response = UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
                }
                else
                {
                    new ProjectController().UpdateHours(int.Parse(projectID), float.Parse(design), float.Parse(doing), float.Parse(codeReview), float.Parse(testing), float.Parse(deliverables));
                    response = StatusCode(200, "Hours updated.");
                }
            }
            return response;
        }

        [HttpPatch("Student/Complete")]
        public ActionResult Completed(string projectID)
        {
            ActionResult response;
            projectID = projectID != null ? projectID.Trim().ToLower() : null;

            if (string.IsNullOrEmpty(projectID))
            {
                response = StatusCode(400, "Please enter a project ID.");
            }
            else
            if (!int.TryParse(projectID, out int _projectID))
            {
                response = StatusCode(400, "ID's must be positive integers.");
            }
            else
            {
                try
                {
                    new ProjectController().Complete(_projectID);
                    response = StatusCode(200, "Well done! Project complete.");
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }
            return response;
        }

        [HttpPatch("Student/Archive")]
        public ActionResult Archive(string projectID)
        {
            ActionResult response;
            projectID = projectID != null ? projectID.Trim().ToLower() : null;

            if (string.IsNullOrEmpty(projectID))
            {
                response = StatusCode(400, "Please enter a project ID.");
            }
            else
            if (!int.TryParse(projectID, out int _projectID))
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
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }
            return response;
        }

        [Authorize(Roles = Roles.Instructor)]
        [HttpGet("Instructor")]
        // get a list of all the projects
        public ActionResult<List<ProjectDTO>> GetAllProjects()
        {
            return new ProjectController().GetAllProjects();
        }


        // Instructor to create project
        [Authorize(Roles = Roles.Instructor)]
        [HttpPost("Instructor/Create")]
        public ActionResult CreateProject(string projectName, string dueDate, string employeeID)
        {
            ValidationExceptions exceptions = new ValidationExceptions();
            projectName = projectName != null ? projectName.Trim() : null;
            dueDate = dueDate != null ? dueDate.Trim() : null;
            employeeID = employeeID != null ? employeeID.Trim() : null;

            if (string.IsNullOrEmpty(projectName))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must include project name."));
            }

            if (string.IsNullOrEmpty(dueDate))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must include due date."));
            }
            else
            if (!DateTime.TryParse(dueDate, out DateTime _dueDate))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The date format is not correct."));
            }
            else
            if (DateTime.Compare(_dueDate, DateTime.Today) < 0)
            {
                exceptions.SubExceptions.Add(new ArgumentException("The due date has to be in the future."));
            }


            if (string.IsNullOrEmpty(employeeID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Employee ID must be included to assign the project."));
            }
            else
            if (!int.TryParse(employeeID, out int _employeeID))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The employee ID must be in number format."));
            }

            if (exceptions.SubExceptions.Count > 0)
            {
                return UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
            }
            else
            {
                try
                {
                    new ProjectController().CreateProject(projectName, DateTime.Parse(dueDate), int.Parse(employeeID));
                    return StatusCode(200, $"Project {projectName} succesfully created. It has deadline of {dueDate} and it is assigned to student with ID of {employeeID}");
                }
                catch (ValidationExceptions e)
                {

                    return UnprocessableEntity(new { errors = e.SubExceptions.Select(x => x.Message) });
                }
            }

        }

        [Authorize(Roles = Roles.Instructor)]
        [HttpGet("Instructor/CreateByCohort")]
        public ActionResult CreateProjectByCohort(string projectName, string dueDate, string cohort, string isCohortProject)
        {
            isCohortProject = isCohortProject != null ? isCohortProject.Trim().ToLower() : null;
            projectName = projectName != null ? projectName.Trim() : null;
            dueDate = dueDate != null ? dueDate.Trim() : null;
            cohort = cohort != null ? cohort.Trim() : null;

            ValidationExceptions exceptions = new ValidationExceptions();

            if (string.IsNullOrEmpty(projectName))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must include project name."));
            }

            if (string.IsNullOrEmpty(dueDate))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must include due date."));
            }
            else
            if (!DateTime.TryParse(dueDate, out DateTime _dueDate))
            {
                exceptions.SubExceptions.Add(new ArgumentException("The date format is not correct."));
            }
            else
            if (DateTime.Compare(_dueDate, DateTime.Today) < 0)
            {
                exceptions.SubExceptions.Add(new ArgumentException("The due date has to be in the future."));
            }

            if (string.IsNullOrEmpty(cohort))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must enter a cohort number."));
            }
            else
            if (!float.TryParse(cohort, out float _cohort))
            {
                exceptions.SubExceptions.Add(new ArgumentException("Must enter a proper format."));
            }

            if (exceptions.SubExceptions.Count > 0)
            {
                return UnprocessableEntity(new { errors = exceptions.SubExceptions.Select(x => x.Message) });
            }
            else
            if (bool.TryParse(isCohortProject, out bool _isCohortProject))
            {
                new ProjectController().CreateProjectForCohort(projectName, DateTime.Parse(dueDate), float.Parse(cohort));
                return StatusCode(200, $"Project {projectName} succesfully created. It has deadline of {dueDate} and it is assigned to cohort {cohort}");
            }
            else
            {
                return StatusCode(400, "Must enter either true or false.");
            }

        }
    }
}
