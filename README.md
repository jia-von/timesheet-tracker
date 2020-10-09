# Timesheet Tracker
[![Project Status: Active – The project has reached a stable, usable state and is being actively developed.](https://www.repostatus.org/badges/latest/active.svg)](https://www.repostatus.org/#active)

Jia and Osa from Input/Output submitted a proposal on September 30, 2020, to develop a Timesheet Tracker application that will replace the current format of [4.1] Master TECHCareers Timesheet Tracker (Master Timesheet). Master Timesheet was created using the Google Sheet platform and was released on July 15, 2020.  Since the release of the Master Timesheet, it has been inconvenient for students to use as it requires initial training, students to search their tabs and dates to enter their hours in specified columns. Additionally, instructors have difficulties tracking hours submitted by students and to analyze which student requires the most help based on hours submitted for a project. Timesheet Tracker will simplify timesheet submission for students and analyses for instructors by using a full-stack web application. 

## Prerequisites
- Timesheet Tracker requires [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) and [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1)
- This application uses [ReactJS.NET](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.1&tabs=visual-studio) on ASP.NET Core and requires a few packages installation through [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget)
- [Entity Framework (EF) Core](https://docs.microsoft.com/en-us/ef/core/) is used in this application to perform data access against the [MySQL](https://dev.mysql.com/doc/refman/5.7/en/) database ([MariaDB](https://mariadb.org/)) and server ([Apache](https://httpd.apache.org/))
- This application requires the use of [Code First Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) using EF in .NET Core to set up databases with dummy data
- This application requires a fundamental knowledge of [SQL](https://dev.mysql.com/doc/refman/5.7/en/) Syntax
- Developers tools such as [XAMPP](https://www.apachefriends.org/index.html) and [Postman](https://www.postman.com/) are recommended to engage, test, and use this application

## Installation
Within [Git](https://git-scm.com/) run these commands
```bash
$ git clone https://github.com/TECHCareers-by-Manpower/capstone-project-input-output.git
$ cd capstone-project-input-output
$ devenv start
```

Installations of Entity Framework Core can be done either through [NuGet Package Manager for Solution...](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio) or through Visual Studio 2019 [NuGet Package Manager Console](https://docs.microsoft.com/en-us/ef/core/get-started/install/) (Package Manager), check for `Program.cs` in the file directory, within the same directory, run these commands
```bash
PM> dotnet add package Microsoft.EntityFrameworkCore.Design
PM> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
PM> dotnet add package Pomelo.EntityFrameworkCore.MySql
````

Installations of packages relating to ReactJS.NET libraries can be done through the Package Manager by running these [commands](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.1&tabs=visual-studio)
```bash
PM> cd ClientApp
PM> npm install
PM> npm install axios
````

To establish a database (within MariaDB) with pre-populated dummy data requires the execution of Code First Migrations. Run these commands to initiate migration within the `Program.cs` file directory
```bash
PM> dotnet ef add migrations StartUp
PM> dotnet ef database update
```

If there are any errors that occur during the migrations, kindly refer to the [EF Core tools reference](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet) to troubleshoot.  

## Usage


## Acknowledgement
Timesheet Tracker is part of a Capstone Project issued by TECHCareers for students to create a primary portfolio from this TECHCareers Full-Stack Software Developer Program. This project will help students to develop a professional level quality portfolio piece with the guidance from TECHCareers instructors. 

## References