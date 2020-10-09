using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.Exceptions;

namespace Timesheet_Tracker.Controllers
{
    public class ProjectController : Controller
    {
        // Create
        // Create project with parameters, project name, due date, date creation, employee_id
        public int CreateProject(string projectName, DateTime dueDate, int employeeID)
        {
            int target;

            // Create Validation Exception to catch any exceptions that is related to database error such as taken email, taken id, and taken name.
            ValidationExceptions exception = new ValidationExceptions();

            using (TimesheetContext context = new TimesheetContext())
            {

                // The project cannot be assigned to employee twice
                // Only instructor can make projects and assign projects
                // Example: JavaScript Assignment cannot be assigned twice
                // Any employee that have that project assigned, the project cannot be created and an response will be created.
                
                // Find the employee first
                if(!context.Employees.Any(x => x.ID == employeeID))
                {
                    exception.SubExceptions.Add(new ArgumentException($"The student with ID of {employeeID} cannot be found in the database."));
                }
                else
                if (context.Projects.Where(x => x.EmployeeID == employeeID).Single().ProjectName == projectName)
                {
                    // Find the employee's project name assigned
                    exception.SubExceptions.Add(new ArgumentException($"This project, {projectName} has been assigned to this student with ID: {employeeID}."));
                }
                
                if(exception.SubExceptions.Count > 0)
                {
                    throw exception;

                }
                else
                {
                    // If no exceptions are thrown, the project will be created for the student, and will return a project ID integer. 
                    Project newProject = new Project()
                    {
                        ProjectName = projectName,
                        DueDate = dueDate,
                        EmployeeID = employeeID
                    };

                    context.Add(newProject);
                    context.SaveChanges();
                    target = newProject.ID;
                }

            }
            // This will return a projectID number.
            return target;
        }

        // Read
        // Get all list of the projects and students for instructors, it can further filtered by: project name, studentID, duedate, ordered by total hours
        public List<Project> GetAllProjects(string input)
        {
            using(TimesheetContext context = new TimesheetContext())
            {
                switch (input)
                {
                    case "projectName":
                        if (!context.Projects.Any(x => x.ProjectName == input))
                        {
                            throw new ArgumentNullException($"This project {input} does not exist.");
                        }
                        else
                        {
                            return context.Projects.Where(x => x.ProjectName == input).ToList();
                        }
                    case "employeeID":
                        if (!context.Projects.Any(x => x.EmployeeID == int.Parse(input)))
                        {
                            throw new ArgumentNullException($"This student with ID, {input} does not exist in the current database.");
                        }
                        else
                        {
                            return context.Projects.Where(x => x.EmployeeID == int.Parse(input)).ToList();
                        }
                    case "dueDate":
                        if (!context.Projects.Any(x => x.DueDate == DateTime.Parse(input)))
                        {
                            throw new ArgumentNullException($"The date entered, {input} is unavailable.");
                        }
                        else
                        {
                            return context.Projects.Where(x => x.DueDate == DateTime.Parse(input)).ToList();
                        }
                    default:
                        return context.Projects.Select(x => x).ToList();

                }
            }
        }


        // Get a list of projects based on employeeID of student, for student to view their projects
        public List<Project> GetProjectListForStudent(int employeeID)
        {
            List<Project> studentProjects;

            using(TimesheetContext context = new TimesheetContext())
            {
                // Filter the projects based on employeeID
                studentProjects = context.Projects.Where(x => x.EmployeeID == employeeID).ToList();
            }

            return studentProjects;
        }

        // Get one project for student and return one project for student based on name, return projectID
        public int GetProjectForStudent(string projectName, int employeeID)
        {
            Project studentProject;
            List<Project> projectList;
            using(TimesheetContext context = new TimesheetContext())
            {
                projectList = GetProjectListForStudent(employeeID);
                studentProject = projectList.Where(x => x.ProjectName == projectName).Single();
            }

            return studentProject.ID;
        }

        // Order the project Due Date appearing at the top with filtered ID
        public List<Project> StudentProjectsOrdered(int employeeID)
        {
            List<Project> target;
            using(TimesheetContext context = new TimesheetContext())
            {
                target = GetProjectListForStudent(employeeID).OrderByDescending(x => x.DueDate).ToList();
            }
            return target;
        }

        // Update
        // Student update hours based on the type of hours
        // Student must have asignments to add hours to project
        // Only student can add hours to their project, such as JavaScript

        public int UpdateHours(int projectID, float? design, float? doing, float? codeReview, float? testing, float? deliverables)
        {
            Project project;
            using(TimesheetContext context = new TimesheetContext())
            {
                project = context.Projects.Where(x => x.ID == projectID).Single();
                project.DesignHours += design;
                project.DoingHours += doing;
                project.CodeReviewHours += codeReview;
                project.TestingHours += testing;
                project.DeliverablesHours += deliverables;
                context.SaveChanges();
            }
            return project.ID;
        }

        // Archive
        public int Archive(int projectID)
        {
            Project target;
            using (TimesheetContext context = new TimesheetContext())
            {
                if (!context.Projects.Any(x => x.ID == projectID))
                {
                    throw new ArgumentNullException($"No project with {projectID} recorded in the employee database.");
                }
                else
                {
                    target = context.Projects.Where(x => x.ID == projectID).Single();
                    target.Archive = true;
                    context.SaveChanges();
                }
                return target.ID;
            }
        }


        // Hours calculation and analysis
        // Calculate the total hours for each unique ProjectID
        public float TotalHours(int projectID)
        {
            Project target;
            float sumHours;

            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Projects.Where(x => x.ID == projectID).Single();
                sumHours = target.DesignHours.Value + target.DoingHours.Value + target.CodeReviewHours.Value + target.TestingHours.Value + target.DeliverablesHours.Value;
            }
            return sumHours;
        }

        // Calculate the average hours for each projectName
        public void AverageHours(string projectName)
        {
            List<Project> target;
            float averageTotal, averageDesign, averageDoing, averageCodeReview, averageTesting, averageDeliverables;
            using (TimesheetContext context = new TimesheetContext())
            {
                // Find the project
                target = context.Projects.Where(x => x.ProjectName == projectName).ToList();
                averageDesign = target.Average(x => x.DesignHours).Value;
                averageDoing = target.Average(x => x.DesignHours).Value;
                averageCodeReview = target.Average(x => x.CodeReviewHours).Value;
                averageTesting = target.Average(x => x.TestingHours).Value;
                averageDeliverables = target.Average(x => x.DeliverablesHours).Value;
                averageTotal = averageDesign + averageDoing + averageCodeReview + averageTesting + averageDeliverables;
            }
        }

    }
}
