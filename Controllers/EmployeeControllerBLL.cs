using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        // Create
        // id: person_id, instructor: true/false, cohort: float such as 4.1
        public int CreateEmployee(int personID, bool instructor, float cohort)
        {
            Employee target;
            ValidationExceptions exceptions = new ValidationExceptions();
            using(TimesheetContext context = new TimesheetContext())
            {
                // has to validate that Employee cannot be created twice for the same PersonID
                if(context.Employees.Any(x => x.PersonID == personID))
                {
                    exceptions.SubExceptions.Add(new ArgumentException($"This person with ID, {personID} is already an employee of the database."));
                }

                if(exceptions.SubExceptions.Count>0)
                {
                    throw exceptions;
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
        public List<Employee> GetAllEmployees(string input)
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
                            return context.Employees.Where(x => x.Instructor == true).ToList();
                            
                        }
                    case "student":
                        if(!context.Employees.Any(x => x.Instructor == false))
                        {
                            throw new ArgumentException("No student recorded in the employee database.");
                        }
                        else
                        {
                            return context.Employees.Where(x => x.Instructor == false).ToList();
                        }
                    default:
                        return context.Employees.Select(x => x).ToList();
                }
            }
        }

        // Get list of students by cohort
        public List<Employee> GetAllStudentsByCohort(float input)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x =>x.Cohort == input))
                {
                    throw new ArgumentNullException($"No cohort, {input} recorded in the employee database.");
                }
                else
                {
                    return context.Employees.Where(x => x.Cohort == input).ToList();
                }
            }
        }

        // Get employee by id
        public int GetEmployeeByID(int employeeID)
        {
            Employee target;
            using (TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x => x.ID == employeeID))
                {
                    throw new ArgumentNullException($"No employee with {employeeID} recorded in the employee database.");
                }
                else
                {
                    target = context.Employees.Where(x => x.ID == employeeID).Single();
                }
            }
            return target.ID;
        }

        // Display first name and last name for instructor use
        public string GetFullName(int employeeID)
        {
            string firstName, lastName;
            using(TimesheetContext context = new TimesheetContext())
            {
                if (!context.Employees.Any(x => x.ID == employeeID))
                {
                    throw new ArgumentNullException($"No employee with {employeeID} recorded in the employee database.");
                }
                else
                {
                    firstName = context.Employees.Where(x => x.ID == employeeID).Single().Person.FirstName;
                    lastName = context.Employees.Where(x => x.ID == employeeID).Single().Person.LastName;
                }
                return $"{firstName} {lastName}";
            }
        }

        // Update
        public int UpdateEmployee(int employeeID, bool instructor, float cohort)
        {
            Employee target;
            using(TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x => x.ID == employeeID))
                {
                    throw new ArgumentNullException($"No employee with {employeeID} recorded in the employee database.");
                }
                else
                {
                    target = context.Employees.Where(x => x.ID == employeeID).Single();
                    target.Instructor = instructor;
                    target.Cohort = cohort;
                    context.SaveChanges();
                }
                return target.ID;
            }
        }
        // Delete
    }
}
