

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
        // This template is from 4.1-ReactAPI project @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Controllers
        // Authorization method is cited from ASP.NET Core 3.1 - Role Based Authorization Tutorial with Example API @link: https://jasonwatmore.com/post/2019/10/16/aspnet-core-3-role-based-authorization-tutorial-with-example-api#authenticate-model-cs
        // assign a private person controller which is set when an instance of this api controller is created
        // this will be used to interact with the person controller
        private PersonController _personController;
        public PersonControllerAPI(PersonController personController)
        {
            _personController = personController;
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
                if (lastName == null) badInputs.Add("last name");
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

                        Employee employeeInfo = employeeController.GetEmployeeIDByPersonID(person.ID);

                        person.Cohort = employeeInfo.Cohort;
                        person.Instructor = employeeInfo.Instructor;
                        person.EmployeeID = employeeInfo.ID;
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

        // update a user account
        [HttpPatch("Update")]
        public ActionResult UpdateUserAccount(string personID, string firstName, string lastName, string currentPassword, string newPassword, string isUpdatingPassword)
        {
            // proceed if all values were provided, else return info on which values are required
            if (personID != null && firstName != null && lastName != null && currentPassword != null && newPassword != null && isUpdatingPassword != null)
            {
                // convert is updating password to a boolean value
                bool updatePassword = isUpdatingPassword == "true";
                // attempt to update the new person or return errors
                try
                {
                    // try converting the id to an integer
                    int intPersonID = Convert.ToInt32(personID);
                    //PersonController controller = new PersonController();
                    string result = _personController.UpdateAccount(intPersonID, firstName.Trim(), lastName.Trim(), currentPassword.Trim(), newPassword.Trim(), updatePassword);

                    return StatusCode(200, result);
                }
                catch (InvalidOperationException)
                {
                    return StatusCode(400, "Something went wrong. Please check your internet/database connection");
                }
                catch (Exception e)
                {
                    return StatusCode(400, e.Message);
                }
            }
            else
            {
                // return errors if any values are null
                List<string> badInputs = new List<string>();
                if (personID == null) badInputs.Add("person ID");
                if (currentPassword == null) badInputs.Add("current password");
                if (firstName == null) badInputs.Add("first name");
                if (lastName == null) badInputs.Add("last name");
                if (newPassword == null) badInputs.Add("new password");
                if (isUpdatingPassword == null ) badInputs.Add("isUpdatingPassword");
                return StatusCode(400, $"Values for {String.Join(", ", badInputs)} must be provided");
            }
        }
        
        // archive the person, their projects and their employee records
        [HttpDelete("Delete")]
        public ActionResult DeletePerson(string personID)
        {
            // TODO ensure the user calling delete matches the entity being deleted
            // read here https://stackoverflow.com/questions/38340078/how-to-decode-jwt-token
            // responses from pato milan and jenson-button-event
            try
            {
                int ID = Convert.ToInt32(personID);
                //PersonController controller = new PersonController();
                // attempt to archive the account, return an error if this fails
                try
                {
                    String result = _personController.DeletePersonByID(ID);
                    return StatusCode(200, result);
                } catch (Exception e)
                {
                    return StatusCode(400, e.Message);
                }

            }
            catch (Exception)
            {
                return StatusCode(400, $"ID: {personID} is not valid. Use integers only");
            }
        }
    }
}

