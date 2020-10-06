using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Timesheet_Tracker.Models;

namespace Timesheet_Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        // Create
        // id: person_id, instructor: true/false, cohort: float such as 4.1
        public Employee CreateEmployee(int id, bool instructor, float cohort)
        {
            Employee target;
            using(TimesheetContext context = new TimesheetContext())
            {
                Employee newEmployee = new Employee()
                {
                    PersonID = id,
                    Instructor = instructor,
                    Cohort = cohort
                };
                context.Add(newEmployee);
                context.SaveChanges();
                target = newEmployee;
            }
            return target;
        }

        // Read
        // Get a list of employees based on input: all, intructor, student, or cohort number
        public List<Employee> GetEmployeesList(string input)
        {
            List<Employee> employeeList;

            using(TimesheetContext context = new TimesheetContext())
            {
                if (input == "all")
                {
                    employeeList = context.Employees.Select(x => x).ToList();
                }
                else
                if(input == "instructor")
                {
                    employeeList = context.Employees.Where(x => x.Instructor == true).ToList();
                }
                else
                if(input == "student")
                {
                    employeeList = context.Employees.Where(x => x.Instructor == false).ToList();
                }
                else
                {
                    int tempFloat = int.Parse(input);
                    employeeList = context.Employees.Where(x => x.Cohort == tempFloat).ToList();
                }
            }
            return employeeList;
        }

        // Get employee by id
        public Employee GetEmployeeByID(int id)
        {
            Employee target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Employees.Where(x => x.ID == id).SingleOrDefault();
            }
            return target;
        }

        // Update
        public Employee UpdateEmployee(int id, bool instructor, float cohort)
        {
            Employee target;
            using(TimesheetContext context = new TimesheetContext())
            {
                target = context.Employees.Where(x => x.ID == id).SingleOrDefault();
                target.Instructor = instructor;
                target.Cohort = cohort;
            }
            return target;
        }
        // Delete
    }
}
