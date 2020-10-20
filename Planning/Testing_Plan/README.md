# Application Guide
This document will guide the user to operate the Timesheet Tracker application within the ASP.NET Core application. Installation instructions and guides are provided within README.md repository on GitHub. The objectives of this guide are to operate Timesheet Tracker and to test the application using Arrange, Act, and Assert concept.

## Startup
Following instructions provided in the README.md, debug the Timesheet Tracked application within Visual Studio Community. It may take a couple of minutes for the application to start due to the npm installations dependencies. However, this only will run once when the application first starts. 

## Create Account
The figure shows the application homepage, in this page, the user can sign-in or create an account. 
1. To create an account, click “Create an account”.
2. There are two options to create an account based on roles, Instructors or Student.
3. When the creation of an account is a success, the user will be redirected to the homepage. 

| Homepage  | Sign Up | Instructor Sign Up  | Student Sign Up |
| ------------- | ------------- | ------------- | ------------- |
| ![homepage](Screenshots/homepage.PNG) | ![signup](Screenshots/signup.PNG) | ![instructor signup](Screenshots/instructor_signup.PNG) | ![student signup](Screenshots/student_signup.PNG) |

## Sign In

After an account was created, the user can sign in based on the email and password sign up. The user will be redirected to pages depending on the role, Instructor or Student. 

## Instructor

The instructor can view list of projects created and assigned to student, charts, update account, create project and sign out. 

### Charts

There are three charts available for instructor to view.
- Doughnut chart calculates the average hours per project type or assignment name, eg. PHP API Assignment.
- The bar chart compares the maximum and minimum hours spent per project, eg. PHP API Assignment. The average bar allows the instructor to compare the differences between minimum and maximum values against the average student population. 
- This histogram chart allows the instructor to analyze the difficulty of their assignment. A good assignment should have symmetric shape. Skewing left or skewing right could indicate that the assignment is either too difficult or too easy. 

| Doughnut  | Bar | Histogram |
| ------------- | ------------- | ------------- |
| ![doughnut](Screenshots/doughnut_chart.PNG)  | ![bar](Screenshots/bar_chart.PNG)  | ![histogram](Screenshots/Histogram_Chart.PNG) |

This is an example from [Mike Yi](https://chartio.com/learn/charts/histogram-complete-guide/) indicating the variety of histogram shapes.
![histogram variety](Screenshots/histogram-variaties.png)

### Create Project

The figures below, show the fields required to be entered to create a project, eg. JavaScript DOM Assignment that is due on October 22, 2020 at 9:00 am. The instructor will have a choice to either assign the project to a student based or to a cohort. A message will return if the project is succesfully created. 

| Assign to a Student  | Assign to a Cohort | Success Message |
| ------------- | ------------- | ------------- |
| ![To a Student](Screenshots/create_project_individual.PNG)  | ![To a Cohort](Screenshots/create_project_cohort.PNG)  | ![Project Success Message](Screenshots/create_project_success.PNG) |

### Update Account

The instructor can update their name, password, and email on their account as shown below:

![Update Account](Screenshots/update_account.PNG)
 
## Student

The student can view list of projects that were assigned to them. Student can update hours for their project, update account, and sign out. 

### Update Hours

Student is able to update the hours and track the hours accumulated. Bar chart display will help student evaluate the hours accumulated for the type of task. Additionally, student is able to mark the project as completed and archive the project using delete project button. The figures below show the input fields and chart available for student.

| Update Hours Field  | Update Success | Bar Chart |
| ------------- | ------------- | ------------- |
| ![Update Hours Field](Screenshots/student_update_hours.PNG)  | ![Update Hours Success](Screenshots/updated_hours_success.PNG)  | ![Student Hours Chart](Screenshots/student_hours_chart.PNG) |



