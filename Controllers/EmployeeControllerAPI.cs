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

            try
            {
                response = new EmployeeController().GetAllEmployees(input);
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }
            return response;
        }

        // input can be cohort number format must be made sure that it has been formatted correctly as 4.1
        [HttpGet("Instructor/GetCohort")]
        public ActionResult<List<EmployeeDTO>> GetCohort(string input)
        {
            ActionResult<List<EmployeeDTO>> response;
            float cohort = float.Parse(input);
            try
            {
                response = new EmployeeController().GetAllStudentsByCohort(cohort);
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }
            return response;
        }

        [HttpGet("Instructor/{id}")]
        public ActionResult <Employee> GetEmployeeByID(string id)
        {
            ActionResult<Employee> response;
            int employeeID = int.Parse(id);

            try
            {
                response = new EmployeeController().GetEmployeeByID(employeeID);
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }
            return response;
        }

        [HttpPost("Create")]
        // instructor can be a yes or no button, or check box. 
        public ActionResult CreateEmployee(string personID, string instructor, string cohort)
        {
            ActionResult response;

            int ID = int.Parse(personID);
            bool instructorYesNo = instructor == "true" ? true : false;
            float cohortNumber = int.Parse(cohort);

            try
            {
                new EmployeeController().CreateEmployee(ID, instructorYesNo, cohortNumber);
                response = Ok(new { message = $"Successfully created an employee."});

            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
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
