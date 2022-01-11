# DecathlonWebshop

## Project Description
This is my first web application.
The goal of this project was to get familiar with the ASP.NET Core environment on the basis of a real project.

I chose to make a pie webshop, inspired by Gill Cleeren's Pluralsight Course: Building Web Applications with ASP.NET Core MVC.

With this project I learned following topics:
- ASP.NET Core MVC
- Bootstrap
- Dependency Injection
- Entity Framework Core
- User Authentication and Authorization using ASP.NET Core Identity (Users, Roles and claims)
- Multilingual applications using .NET Core Localization
- Ajax calls
- Restful API with Swagger


## Platform Requirements
- .NET 5
- Visual Studio 2019
- SQL Server 2019

## How to Install and Run the Project
1. Fork the project
2. Create a local sql server database named "DecathlonWebshop" and modify the connection string in the appsettings.json file.
3. Update the previous created database with the "update-database" command in the package manager console. This will update the database using the migration files.
   Basic data is already seeded into the database for a working application.
4. The webshop is equipped with Google External Authentication. Therefore the ClientId and ClientSecret have to be added in the User Secrets file.
   To avoid this step, lines 64-68 can be commented out in the Startup.cs file.
5. Run the project

## How to use the project
- To access all the functionalities, log in with the admin account.<br/>
username = admin <br/>
password = Password123! <br/>
Now you are able to create, edit and remove new products and users. As well as user management.
- In developer mode the development error page is used, in production mode all exceptions and 404 errors are caught in the custom error page.
- The Swagger can be reached at "/swagger".
- The tokens generated for password reset and email confirmation are logged in the console, debug or log file with location 'C:\temp'.

## Credits
I would strongly recommend Gill Cleeren's Pluralsight Course: [Building Web Applications with ASP.NET Core MVC](https://www.pluralsight.com/courses/building-aspdotnet-core-mvc-web-applications)<br/>Everything is built step by step and clearly explained so that you are able to build a working web shop in a relatively short time.

## External links
- [Google external login setup in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-6.0)

- [Package Manager Console Commands](https://www.learnentityframeworkcore.com/migrations/commands/pmc-commands)
