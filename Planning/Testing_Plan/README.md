# Application Guide
This document will guide the user to operate the Timesheet Tracker application within the ASP.NET Core application. Installation instructions and guides are provided within README.md repository on GitHub. The objectives of this guide are to operate Timesheet Tracker and to test the application using Arrange, Act, and Assert concept.

## Startup
Following instructions provided in the README.md, debug the Timesheet Tracked application within Visual Studio Community. It may take a couple of minutes for the application to start due to the npm installations dependencies. However, this only will run once when the application first starts. 

## Create Account
The figure shows the application Homepage, in this page, the user can sign-in or create an account. To create an account, click “Create an account”.

| Homepage  | Sign Up |
| ------------- | ------------- |
| ![homepage](Screenshots/homepage.PNG) | ![signup](Screenshots/signup.PNG) |

There are two options to create an account based on roles, Instructors or Student. The examples are shown below:

| Instructor  | Student |
| ------------- | ------------- |
| ![instructor signup](Screenshots/instructor_signup.PNG) | ![student signup](Screenshots/student_signup.PNG) |

When the creation of an account is a success, the user will be redirected to the homepage. 

## Sign In

After an account was created, the user can sign in based on the email and password sign up. The instructor can view the list of assignments created and assigned to students. Project name, hours, date created and date ended can be viewed in the list form. 

### Charts

There are three charts available for instructor to view.

Doughnut chart calculates the average hours per project type or assignment name, eg. PHP API Assignment.

![doughnut](Screenshots/doughnut_chart.PNG)

The bar chart compares the maximum and minimum hours spent per project, eg. PHP API Assignment. The average bar allows the instructor to compare the differences between minimum and maximum values against the average student population. 
![bar](Screenshots/bar_chart.PNG)

This histogram chart allows the instructor to analyze the difficulty of their assignment. A good assignment should have symmetric shape. Skewing left or skewing right could indicate that the assignment is either too difficult or too easy. 
![histogram](Screenshots/Histogram_Chart.PNG)

This is a example from [Mike Yi](https://chartio.com/learn/charts/histogram-complete-guide/) indicating the variety of histogram shapes.
![histogram variety](histogram-variaties.png)




 

