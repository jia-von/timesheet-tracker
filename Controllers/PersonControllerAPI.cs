

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;

namespace Timesheet_Tracker.Controllers
{
    [Authorize]
    [Route("Person")]
    [ApiController]
    public class PersonControllerAPI : ControllerBase
    {
        // assing a private person controller which is set when an instance of this api controller is created 
        private PersonController _personController;
        public PersonControllerAPI(PersonController personController)
        {
            _personController = personController;
        }

        // /Person => List of all entries in Person table
        [Authorize(Roles = Roles.Instructor)]
        [HttpGet("")]
        public ActionResult<List<Person>> GetAll()
        {
            var people = _personController.GetAllPerson();
            return people;
        }

        // /Person?id=1 => Person with the id = 1
        [HttpGet("ID")]
        public ActionResult<PersonDTO> GetPersonByID(string id)
        {
            if (id != null)
            {
                // attempt to parse the id into an int
                try
                {
                    int ID = Convert.ToInt32(id);
                    //PersonController controller = new PersonController();
                    Person person = _personController.GetPersonByID(ID);

                    if (person == null)
                    {
                        return StatusCode(400, $"Person with ID: {id} was not found");
                    }
                    else
                    {
                        // create a DTO to prevent returning a person's authentication credentials
                        EmployeeController employeeController = new EmployeeController();
                        Employee employeeInfo = employeeController.GetEmployeeIDByPersonID(person.ID); // changed by Jia, October 12, 2020

                        // Jia added GET a list for projects belonging to this person, get a list of project related to the person.
                        ProjectController projectController = new ProjectController();
                        List<string> employeeProjects = projectController.GetProjectListForStudent(employeeInfo.ID).Select(x => x.ProjectName).ToList();

                        PersonDTO personDTO = new PersonDTO()
                        {
                            ID = person.ID,
                            Email = person.Email,
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            Cohort = employeeInfo.Cohort,
                            Instructor = employeeInfo.Instructor,
                            // Projects = GET a list of projects belonging to this person
                            // Added by Jia, October 12, 2020
                            Projects = employeeProjects

                        };
                        return personDTO;
                    }

                }
                catch (Exception)
                {
                    return StatusCode(400, $"ID: {id} is not valid. Use integers only");
                }
            } else
            {
                return StatusCode(400, "A valid id must be provided");
            }
        }


        // /Person/Create?email=&firstName=&lastName=&password= => ID = {id of the new person created}
        [AllowAnonymous]
        [HttpPost("Create")]
        public ActionResult CreatePerson(string email, string firstName, string lastName, string password, string isInstructorString, float? cohort)
        {
            if (email != null && firstName != null && lastName != null && password != null && isInstructorString != null && cohort != null)
            {
                // convert the is instructor string to a boolean value
                bool isInstructor = isInstructorString == "instructor";
                // attempt to create the new person or return errors
                try
                {
                    //PersonController controller = new PersonController();
                    int ID = _personController.Create(firstName.Trim(), lastName.Trim(), password.Trim(), email.Trim(), isInstructor);
                    // create the corresponding employee record
                    EmployeeController employeeController = new EmployeeController();
                    int _ = employeeController.CreateEmployee(ID, isInstructor, (float)cohort);
                    return Ok(new { ID });
                }
                catch (InvalidOperationException)
                {
                    return StatusCode(400, "Something went wrong. Please check your internet/database connection");
                }
                catch (Exception e)
                {
                    return StatusCode(400, e.Message );
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
                if (isInstructorString == null) badInputs.Add("isInstructorString");
                if (isInstructorString != null && isInstructorString == "student"  && cohort == null) badInputs.Add("cohort");
                return StatusCode(400, $"Values for {String.Join(", ", badInputs)} must be provided");
            }
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public ActionResult<PersonDTO> Authenticate(string email, string password)
        {
            if (email != null && password != null)
            {
                try
                {
                    //PersonController controller = new PersonController();
                    PersonDTO person = _personController.Authenticate(email, password);

                    if (person != null)
                    {
                        EmployeeController employeeController = new EmployeeController();
                        // TODO Get the employee record
                        // this need to either use context to find employee whose person ID matches person.ID
                        // OR needs a GetEmployeeByPersonID method in the EmployeeController
                        // TODO
                        //Employee employeeInfo = employeeController.GetEmployeeByPersonID(person.ID);
                        // use the DTO to avoid sending back the pass hash and salt


                        return person;
                    }
                    else
                    {
                        return StatusCode(400, $"Username or Password did not match any records");
                    }
                }
                catch (InvalidOperationException)
                {
                    return StatusCode(400, "Something went wrong. Please check your internet/database connection");
                }
            }
            else
            {
                // return errors if any values are null
                List<string> badInputs = new List<string>();
                if (email == null) badInputs.Add("email");
                if (password == null) badInputs.Add("password");
                return StatusCode(400, $"Values for {String.Join(", ", badInputs)} must be provided");
            }
        }

        
        // archive the person, their projects and their employee records
        [Authorize(Roles = Roles.Instructor)] // TODO replace only instructors can delete to allow students delete as well
        [HttpDelete("Delete")]
        public ActionResult DeletePerson(string id)
        {
            // TODO ensure the user calling delete has the ID of the entity being deleted
            try
            {
                int ID = Convert.ToInt32(id);
                //PersonController controller = new PersonController();
                // attempt to archive the account, return an error if this fails
                try
                {
                    String result = _personController.DeletePersonByID(ID);
                    return Ok(new { result });
                } catch (Exception e)
                {
                    return StatusCode(400, e.Message);
                }

            }
            catch (Exception)
            {
                return StatusCode(400, $"ID: {id} is not valid. Use integers only");
            }
        }
    }
}

