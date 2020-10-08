using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    [Route("Employee")]
    [ApiController]
    public class EmployeeControllerAPI : ControllerBase
    {
        // input can be "instructor" and "student"
        [HttpGet("Instructor/All")]
        public ActionResult<List<EmployeeDTO>> GetList(string input)
        {
            ActionResult<List<EmployeeDTO>> response;
            input = input != null ? input.Trim().ToLower() : null;

            if(string.IsNullOrWhiteSpace(input))
            {
                response = StatusCode(400, "The input cannot be empty.");
            }
            else
            {
                try
                {
                    response = new EmployeeController().GetAllEmployees(input);
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }

            return response;
        }

        // input can be cohort number format must be made sure that it has been formatted correctly as 4.1
        [HttpGet("Instructor/GetCohort")]
        public ActionResult<List<EmployeeDTO>> GetCohort(string cohort)
        {
            ActionResult<List<EmployeeDTO>> response;
            cohort = cohort != null ? cohort.Trim().ToLower() : null;
            float _cohort;

            if(string.IsNullOrWhiteSpace(cohort))
            {
                response = StatusCode(400, "Cohort cannot be empty.");
            }
            else
            if(!float.TryParse(cohort, out _cohort))
            {
                response = StatusCode(400, "Cohort has to be a number, example 4.1.");
            }
            else
            {
                try
                {
                    response = new EmployeeController().GetAllStudentsByCohort(float.Parse(cohort));
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }

            return response;
        }

        [HttpGet("Instructor/{id}")]
        public ActionResult <Employee> GetEmployeeByID(string id)
        {
            ActionResult<Employee> response;
            id = id != null ? id.Trim().ToLower() : null;
            int employeeID;
            if(string.IsNullOrWhiteSpace(id))
            {
                response = StatusCode(400, "Employee ID cannot be empty.");
            }
            else
            if(!int.TryParse(id, out employeeID))
            {
                response = StatusCode(400, "Employee ID has to be a number.");
            }
            else
            {
                try
                {
                    response = new EmployeeController().GetEmployeeByID(employeeID);
                }
                catch (Exception e)
                {
                    response = StatusCode(422, e.Message);
                }
            }

            return response;
        }

        [HttpPost("Create")]
        // instructor can be a yes or no button, or check box. 
        public ActionResult CreateEmployee(string personID, string instructor, string cohort)
        {
            ActionResult response;
            ValidationExceptions exceptions = new ValidationExceptions();

            personID = personID != null ? personID.Trim().ToLower() : null;
            instructor = instructor != null ? instructor.Trim().ToLower() : null;
            cohort = cohort != null ? instructor.Trim().ToLower() : null;

            try
            {
                if (string.IsNullOrEmpty(personID))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("To create an employee requires a person ID."));
                }
                else
                if (!int.TryParse(personID, out int _personID))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("The person ID has to be a number."));
                }

                if (string.IsNullOrEmpty(instructor))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Please determine whether the employee is an instructor or student."));
                }
                else
                if (!bool.TryParse(instructor, out bool _instructor))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Please determine whether the employee is an instructor or student."));
                }

                if (!float.TryParse(cohort, out float _cohort))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("Please enter a valid cohort number such as 4.1."));
                }

                if (exceptions.SubExceptions.Count > 0)
                {
                    throw exceptions;
                }
                else
                {
                    try
                    {
                        new EmployeeController().CreateEmployee(int.Parse(personID), bool.Parse(instructor), float.Parse(cohort));
                        response = Ok(new { message = $"Successfully created an employee." });
                    }
                    catch (Exception e)
                    {
                        response = StatusCode(422, e.Message);
                    }
                }
            }
            catch(ValidationExceptions e)
            { 
                response = UnprocessableEntity(new { errors = e.SubExceptions.Select(x => x.Message) });
            }

            return response;
        }

        [HttpPatch("Update")]
        public ActionResult UpdateEmployee(string id, string instructor, string cohort)
        {
            ActionResult response;

            int employeeID = int.Parse(id);
            bool _instructor = instructor == "true" ? true : false;
            float _cohort = float.Parse(cohort);

            try
            {
                new EmployeeController().UpdateEmployee(employeeID, _instructor, _cohort);
                response = Ok(new { message = $"Successfully updated an employee with ID, {id}."});
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }
            return response;
        }

        [HttpPatch("Archive")]
        public ActionResult ArchiveEmployee(string id)
        {
            ActionResult response;
            int employeeID = int.Parse(id);

            try
            {
                new EmployeeController().Archive(employeeID);
                response = Ok(new { message = $"Successfully archive an employee with ID, {id}." });
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }

            return response;
        }

    }
}
