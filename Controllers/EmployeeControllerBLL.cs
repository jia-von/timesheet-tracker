﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;
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
                    FullName = $"{x.Person.FirstName}  {x.Person.LastName}",
                    Instructor = x.Instructor,
                    Cohort = x.Cohort
                }).ToList();
            }
        }

        // Get list of students by cohort
        public List<EmployeeDTO> GetAllStudentsByCohort(float cohort)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x =>x.Cohort == cohort))
                {
                    throw new ArgumentException($"No cohort, {cohort} recorded in the employee database.");
                }
                else
                {
                    return GetAll().Where(x => x.Cohort == cohort).ToList();
                }
            }
        }

        // Get employee by id
        public Employee GetEmployeeByID(int employeeID)
        {
            Employee target;
            using (TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x => x.ID == employeeID))
                {
                    throw new ArgumentException($"No employee with ID,{employeeID} recorded in the employee database.");
                }
                else
                {
                    target = context.Employees.Where(x => x.ID == employeeID).Single();
                }
            }
            return target;
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

        // Archive, it will also archive the many child projects the employeeID has. 
        public int Archive(int employeeID)
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
                    target.Archive = true;

                    // for each project that the employeeID has , the project the have will be archived to true
                    target.Projects.Select(x => x).ToList().ForEach(y => y.Archive = true);
                    context.SaveChanges();
                }
                return target.ID;
            }
        }
    }
}