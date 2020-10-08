using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            EmployeeController list = new EmployeeController();

            try
            {
                response = list.GetAllEmployees(input);
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
            EmployeeController list = new EmployeeController();
            float cohort = float.Parse(input);
            try
            {
                response = list.GetAllStudentsByCohort(cohort);
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
            EmployeeController list = new EmployeeController();
            int employeeID = int.Parse(id);

            try
            {
                response = list.GetEmployeeByID(employeeID);
            }
            catch (Exception e)
            {
                response = StatusCode(422, e.Message);
            }
            return response;
        }
    }
}
