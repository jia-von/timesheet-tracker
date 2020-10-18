﻿using System;
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
using Timesheet_Tracker.Models.DTO;

namespace Timesheet_Tracker.Controllers
{
    public class ProjectController : Controller
    {
        // Create project for individual person
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
                if (context.Projects.Where(x => x.EmployeeID == employeeID).Any(x => x.ProjectName == projectName))
                {
                    // If the employee alreaddy has a project that matches the project being assigned, throw error
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
                        EmployeeID = employeeID,
                        DateCreated = DateTime.Now
                    };

                    context.Add(newProject);
                    context.SaveChanges();
                    target = newProject.ID;
                }

            }
            // This will return a projectID number.
            return target;
        }

        // Create project cohort
        public void CreateProjectForCohort(string projectName, DateTime dueDate, float cohort)
        {
            List<Employee> cohortList;

            using(TimesheetContext context = new TimesheetContext())
            {
                // Filter Cohort First
                cohortList = context.Employees.Where(x => x.Cohort == cohort).ToList();

                // Assigned filtered cohort with assignments using foreach loop.
                foreach(Employee student in cohortList)
                {
                    Project newProject = new Project()
                    {
                        ProjectName = projectName,
                        DueDate = dueDate,
                        EmployeeID = student.ID,
                        DateCreated = DateTime.Now
                    };

                    context.Add(newProject);
                    context.SaveChanges();
                }
            }
        }


        // Read
        // Get all list of the projects and students for instructors, it can further filtered by: project name, studentID, duedate, ordered by total hours
        public List<ProjectDTO> GetAllProjects()
        {
            List<ProjectDTO> target;
            using(TimesheetContext context = new TimesheetContext())
            {
               target = context.Projects.Where(x => x.Archive == false).Select(x => new ProjectDTO()
                {
                    ID = x.ID,
                    ProjectName = x.ProjectName,
                    FullName = $"{x.Employee.Person.FirstName} {x.Employee.Person.LastName}",
                    DueDate = x.DueDate,
                    DateCreated = x.DateCreated,
                    DateCompleted = x.DateCompleted,
                    DesignHours = x.DesignHours,
                    DoingHours = x.DoingHours,
                    CodeReviewHours = x.CodeReviewHours,
                    TestingHours = x.TestingHours,
                    DeliverablesHours = x.DeliverablesHours
                }
                ).ToList();
            }
            return target;
        }

        // Filter by Cohort
        public List<ProjectDTO> GetAllProjectByCohort(float cohort)
        {
            using(TimesheetContext context = new TimesheetContext())
            {
                if(!context.Employees.Any(x => x.Cohort == cohort))
                {
                    throw new ArgumentException($"There is no cohort of {cohort} recorded in the database.");
                }
                else
                {
                    return GetAllProjects().Where(x => x.Cohort == cohort).ToList();
                }
            }
        }

        // Filter by Project Name
        public List<ProjectDTO> GetAllByProjectName(string projectName)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                if (!context.Projects.Any(x => x.ProjectName.ToLower() == projectName))
                {
                    throw new ArgumentException($"There is no project with name of {projectName} recorded in the database.");
                }
                else
                {
                    return GetAllProjects().Where(x => x.ProjectName.ToLower() == projectName).ToList();
                }
            }
        }

        // Filter by Student Name
        public List<ProjectDTO> GetAllProjectByStudentName(string studentName)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                if (!GetAllProjects().Any(x => x.FullName.ToLower() == studentName))
                {
                    throw new ArgumentException($"There is no project with name of {studentName} recorded in the database.");
                }
                else
                {
                    return GetAllProjects().Where(x => x.FullName.ToLower() == studentName).ToList();
                }
            }
        }

        // Filter by Descending order for total hours

        public List<ProjectDTO> GetAllProjectByTotalHours()
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                return GetAllProjects().OrderByDescending(x => x.TotalHours).ToList();
            }
        }

        // For instructor Only
        public ProjectDTO ProjectDetail(int projectID)
        {
            Project target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Projects.Where(x => x.ID == projectID).Single();
                return new ProjectDTO()
                {
                    ID = target.ID,
                    ProjectName = target.ProjectName,
                    FullName = $"{target.Employee.Person.FirstName} and {target.Employee.Person.LastName}",
                    DueDate = target.DueDate,
                    DesignHours = target.DesignHours,
                    DoingHours = target.DoingHours,
                    CodeReviewHours = target.CodeReviewHours,
                    TestingHours = target.TestingHours,
                    DeliverablesHours = target.DeliverablesHours
                };
            }
        }

        // Get a list of projects based on employeeID of student, for student to view their projects
        public List<ProjectDTO> GetProjectListForStudent(int employeeID)
        {
            List<ProjectDTO> studentProjects;
            List<Project> projectList;

            using(TimesheetContext context = new TimesheetContext())
            {   
                    // Filter the project for matching employee ID & unarchived projects only
                    projectList = context.Projects.Where(x => x.EmployeeID == employeeID && x.Archive == false).ToList();

                    // calculate total hours for each project
                    studentProjects = projectList.Select(x => new ProjectDTO()
                    {
                        ID = x.ID,
                        ProjectName = x.ProjectName,
                        DueDate = x.DueDate,
                        DateCreated = x.DateCreated,
                        DateCompleted = x.DateCompleted,
                        DesignHours = x.DesignHours,
                        DoingHours = x.DoingHours,
                        CodeReviewHours = x.CodeReviewHours,
                        TestingHours = x.TestingHours,
                        DeliverablesHours = x.DeliverablesHours
                    }).ToList();

                return studentProjects;
            }

        }

        // Get one project for student and return one project for student 
        public ProjectDTO GetProjectForStudent(int projectID, int employeeID)
        {
            ProjectDTO studentProject;
            List<ProjectDTO> projectList;
            ValidationExceptions exceptions = new ValidationExceptions();

            using(TimesheetContext context = new TimesheetContext())
            {
                if(!context.Projects.Any(x => x.ID == projectID))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("There so such project ID exist."));
                }

                if(!context.Projects.Any(x => x.EmployeeID == employeeID))
                {
                    exceptions.SubExceptions.Add(new ArgumentException("There is no such employee ID recorded in the database."));
                }

                if (exceptions.SubExceptions.Count > 0)
                {
                    throw exceptions;
                }
                else
                {
                    projectList = GetProjectListForStudent(employeeID);
                    studentProject = projectList.Where(x => x.ID == projectID).Single();
                }
            }

            return studentProject;
        }

        // Order the project Due Date appearing at the top with filtered ID
        public List<ProjectDTO> StudentProjectsOrdered(int employeeID)
        {
            List<ProjectDTO> target;
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

        public Project UpdateHours(int projectID, float design, float doing, float codeReview, float testing, float deliverables)
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

                // if any of the values are less than zero, set them to 0 ( no negative values)
                if (project.DesignHours < 0) project.DesignHours = 0;
                if (project.DoingHours < 0) project.DoingHours = 0;
                if (project.CodeReviewHours < 0) project.CodeReviewHours = 0;
                if (project.TestingHours < 0) project.TestingHours = 0;
                if (project.DeliverablesHours < 0) project.DeliverablesHours = 0;

                context.SaveChanges();
            }

            return project;
        }

        // Complete a project
        public int Complete(int projectID)
        {
            Project target;
            using (TimesheetContext context = new TimesheetContext())
            {
                if (!context.Projects.Any(x => x.ID == projectID))
                {
                    throw new ArgumentNullException($"No project with ID {projectID} found.");
                }
                else
                {
                    target = context.Projects.Where(x => x.ID == projectID).Single();
                    target.DateCompleted = DateTime.Now;
                    context.SaveChanges();
                }
                return target.ID;
            }
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
                    target.DateArchive = DateTime.Now;
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
                sumHours = target.DesignHours + target.DoingHours + target.CodeReviewHours + target.TestingHours + target.DeliverablesHours;
            }
            return sumHours;
        }

        // Calculate the average hours for each projectName
        public List<AverageHoursDTO> AverageHours(string projectName)
        {
            List<AverageHoursDTO> target;
            List<Project> projects;

            float averageTotal, averageDesign, averageDoing, averageCodeReview, averageTesting, averageDeliverables;
            using (TimesheetContext context = new TimesheetContext())
            {
                // Find the project based on name
                projects = context.Projects.Where(x => x.ProjectName.ToLower() == projectName.ToLower()).ToList();

                //Calculate average hours. 
                averageDesign = projects.Average(x => x.DesignHours);
                averageDoing = projects.Average(x => x.DesignHours);
                averageCodeReview = projects.Average(x => x.CodeReviewHours);
                averageTesting = projects.Average(x => x.TestingHours);
                averageDeliverables = projects.Average(x => x.DeliverablesHours);
                averageTotal = averageDesign + averageDoing + averageCodeReview + averageTesting + averageDeliverables;

                // Sum the average and return a AverageHoursDTO for view.
                target = projects.Select(x => new AverageHoursDTO()
                {
                    ID = x.ID,
                    ProjectName = x.ProjectName,
                    AverageHours = averageTotal
                }).ToList();
            }
            return target;
        }

    }
}
