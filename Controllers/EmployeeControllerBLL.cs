using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    // This template is from 4.1-ReactAPI project @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Controllers
    public class EmployeeController : Controller
    {
        // Create
        // id: person_id, instructor: true/false, cohort: float such as 4.1
        public int CreateEmployee(int personID, bool instructor, float cohort)
        {
            Employee target;

            using(TimesheetContext context = new TimesheetContext())
            {
                // has to validate that Employee cannot be created twice for the same PersonID
                if(context.Employees.Any(x => x.PersonID == personID))
                {
                    throw new ArgumentException($"This person with ID, {personID} is already an employee of the database.");
                }
                
                if(instructor == true)
                {
                    // if instructor is TRUE, create newInstructor and cohort set to zero
                    Employee newInstructor = new Employee()
                    {
                        PersonID = personID,
                        Instructor = true,
                        Cohort = 0
                    };
                    context.Add(newInstructor);
                    context.SaveChanges();
                    target = newInstructor;
                }
                else
                {
                    // if instrutor is FALSE, create newEmployee and cohort is set to the cohort entered
                    Employee newEmployee = new Employee()
                    {
                        PersonID = personID,
                        Instructor = false,
                        Cohort = cohort
                    };
                    context.Add(newEmployee);
                    context.SaveChanges();
                    target = newEmployee;
                }
                return target.ID;
            }
        }

        // Read
        // Get a list of employees based on input: all, intructor, student
        public List<EmployeeDTO> GetAllEmployees(string input)
        {
            using(TimesheetContext context = new TimesheetContext())
            {
                switch (input)
                {
                    case "instructor":
                        if(!context.Employees.Any(x => x.Instructor == true))
                        {
                            throw new ArgumentNullException("No instructor recorded in the employee database.");
                        }
                        else
                        {
                            return GetAll().Where(x => x.Instructor == true).ToList();
                        }
                    case "student":
                        if(!context.Employees.Any(x => x.Instructor == false))
                        {
                            throw new ArgumentException("No student recorded in the employee database.");
                        }
                        else
                        {
                            return GetAll().Where(x => x.Instructor == false).ToList();
                        }
                    default:
                        return GetAll();
                }
            }
        }

        // Get all the list with model DTO to generate 
        public List<EmployeeDTO> GetAll()
        {
            using(TimesheetContext context = new TimesheetContext())
            {
                return context.Employees.Include(x => x.Person).Select(x => new EmployeeDTO
                {
                    ID = x.ID,
                    FirstName = x.Person.FirstName,
                    LastName = x.Person.LastName,
                    Email = x.Person.Email,
                    Instructor = x.Instructor,
                    Cohort = x.Cohort,
                    Archive = x.Archive
                }).ToList();
            }
        }

        public Employee GetEmployeeIDByPersonID(int personID)
        {
            Employee target;
            using(TimesheetContext context = new TimesheetContext())
            {
                if (!context.Employees.Any(x => x.PersonID == personID))
                {
                    throw new ArgumentException($"No employee with ID,{personID} recorded in the employee database.");
                }
                else
                {
                    target = context.Employees.Where(x => x.PersonID == personID).Single();
                }
            }
            return target;
        }
    }
}
