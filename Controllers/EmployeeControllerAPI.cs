using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    // This template is from 4.1-ReactAPI project @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Controllers
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

    }
}
