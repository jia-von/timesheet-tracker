

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;

namespace Timesheet_Tracker.Controllers
{
    [Route("Person")]
    [ApiController]
    public class PersonControllerAPI : ControllerBase
    {
        // /Person => List of all entries in Person table
        [HttpGet("/")]
        public ActionResult<Object> GetAll()
        {
            PersonController controller = new PersonController();
            var people = controller.GetAllPerson();
            return people;
        }

        // /Person?id=1 => Person with the id = 1
        [HttpGet("ID/")]
        public ActionResult<Person> GetPersonByID(string id)
        {
            // attempt to parse the id into an int
            try
            {
                int ID = Convert.ToInt32(id);
                PersonController controller = new PersonController();
                Person person = controller.GetPersonByID(ID);

                if (person == null)
                {
                    return StatusCode(400, new { NotFound = $"Person with ID: {id} was not found" });
                }
                else
                {
                    return person;
                }

            }
            catch (Exception)
            {
                return StatusCode(400, new { IDError = $"ID: {id} is not valid. Use integers only" });
            }
        }

        // /Person/Create?email=&firstName=&lastName=&password= => ID = {id of the new person created}
        [HttpPost("/Create")]
        public ActionResult CreatePerson(string email, string firstName, string lastName, string password, bool isIntructor, float? cohort)
        {
            if (email != null && firstName != null && lastName != null && email != null && cohort != null)
            {
                // attempt to create the new person or return errors
                try
                {
                    PersonController controller = new PersonController();
                    int ID = controller.Create(firstName.Trim(), lastName.Trim(), password.Trim(), email.Trim());
                    // create the corresponding employee record
                    EmployeeController employeeController = new EmployeeController();
                    int _ = employeeController.CreateEmployee(ID, isIntructor, (float)cohort);
                    return Ok(new { ID });
                }
                catch (Exception e)
                {
                    return StatusCode(400, new { InputError = e.Message });
                }

            }
            else
            {
                // return errors if any values are null
                List<string> badInputs = new List<string>();
                if (email == null) badInputs.Add("email");
                if (password == null) badInputs.Add("password");
                if (firstName == null) badInputs.Add("first name");
                if (lastName == null) badInputs.Add("lastname");
                if (isIntructor == false && cohort == null) badInputs.Add("cohort");
                return StatusCode(400, new { InputError = $"Values for {String.Join(", ", badInputs)} must be provided" });
            }
        }

        [HttpPost("/Authenticate")]
        public ActionResult<PersonDTO> Authenticate(string email, string password)
        {
            if (email != null && password != null)
            {
                PersonController controller = new PersonController();
                Person person = controller.Authenticate(email, password);

                if (person != null)
                {
                    EmployeeController employeeController = new EmployeeController();
                    Employee employeeInfo = employeeController.GetEmployeeByID(person.ID);
                    // use the DTO to avoid sending back the pass hash and salt
                    PersonDTO authenticatedUser = new PersonDTO()
                    {
                        ID = person.ID,
                        Email = person.Email,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Cohort = employeeInfo.Cohort,
                        Instructor = employeeInfo.Instructor,
                        //Projects = GET a list of projects belonging to this person
                    };

                    return authenticatedUser;
                }
                else
                {
                    return StatusCode(400, new
                    {
                        AuthenticationError = $"Username or Password did not match any records"
                    });
                }
            }
            else
            {
                // return errors if any values are null
                List<string> badInputs = new List<string>();
                if (email == null) badInputs.Add("email");
                if (password == null) badInputs.Add("password");
                return StatusCode(400, new
                {
                    InputError = $"Values for {String.Join(", ", badInputs)} must be provided"
                });
            }
        }

        // archive the person, their projects and their employee records
        [HttpDelete("/Delete")]
        public ActionResult DeletePerson(string id)
        {

        }
    }
}

