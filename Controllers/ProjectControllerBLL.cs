using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheet_Tracker.Models;

namespace Timesheet_Tracker.Controllers
{
    public class ProjectController : Controller
    {
        // Create
        // Create project with parameters, project name, due date, date creation, employee_id
        public int CreateProject(string projectName, DateTime dueDate, int employeeID)
        {
            int target;
            using (TimesheetContext context = new TimesheetContext())
            {
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

            return target;
        }

        // Read
        // Get list of stuff, project name, due date, date created, employee id
        public List<Project> GetProjectList(int? employeeID, string projectName, DateTime dateCreated, DateTime dueDate)
        {
            using (TimesheetContext context = new TimesheetContext ())
            {

                if (employeeID != null)
                {
                   return context.Projects.Where(x => x.EmployeeID == employeeID).ToList();
                }
                else
                if(projectName != null)
                {
                    return context.Projects.Where(x => x.ProjectName == projectName).ToList();
                }
                else
                if(dateCreated != null)
                {
                    return context.Projects.Where(x => x.DateCreated == dateCreated).ToList();
                }
                else
                {
                    return context.Projects.Where(x => x.DueDate == dueDate).ToList();
                }

            }

        }

        // get individual stuff, project id, project name
        public Project GetProject(int? projectID, string projectName)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                if(projectID != null)
                {
                    return context.Projects.Where(x => x.ID == projectID).SingleOrDefault();

                }else
                {
                    return context.Projects.Where(x => x.ProjectName == projectName).SingleOrDefault();
                }
            }
        }

        // Update
        // update hours based on the type of hours



        // Delete
    }
}
