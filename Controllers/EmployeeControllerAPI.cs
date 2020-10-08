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
        [HttpGet("All")]
        public ActionResult<List<EmployeeDTO>> GetList(string input)
        {
            ActionResult<List<EmployeeDTO>> response;
            EmployeeController list = new EmployeeController();

            try
            {
                response = list.GetAllEmployees(input);
            }
            catch (ValidationExceptions e)
            {
                response = UnprocessableEntity(new { errors = e.SubExceptions.Select(x => x.Message) });
            }
            return response;
        }
    }
}
