# Stage Race Fantasy
An app for managing custom cylce race fantasy leagues.

## Project background and aims
This year I ran a Tour de France fantasy league for a group of friends and I created an Excel spreadsheet to manage the scoring.  This worked well and largely automated the task of keeping the complex scoring table up to date.  However, it was fairly laborious to update and I thought it would be a perfect candidate for a side project.

As well as solving the problem, I wanted to explore a few new things:
- [Blazor](https://docs.microsoft.com/en-gb/aspnet/core/blazor/?view=aspnetcore-5.0) - A new front end framework from Mirosoft that alows writing web apps in C#.
- [C# 9](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) - The latest itteration of the C# language that has some cool features around immutability such as `records` that I wanted to try out.
- Jason Taylor's [Clean Architecture Template](https://github.com/jasontaylordev/CleanArchitecture) - I watched a few videos including [this one](https://www.youtube.com/watch?v=dK4Yb6-LxAk&t=2706s) by Jason and he had some really interesting ideas that I was eager to try.
- Jason Taylor's [Clean Testing example](https://github.com/jasontaylordev/CleanTesting) - After watching [this](https://www.youtube.com/watch?v=2UJ7mAtFuio) video I was really interested in his idea of "sub-cutanous" testing.

## Running it
This project uses some bleeding edge stuff such as [net5.0](https://devblogs.microsoft.com/dotnet/introducing-net-5/) and C# 9.  I have created the project using Visual Studio 2019 preview which should give you an F5 experience.  If you don't have Visual Studio, you can probably just download the net5.0 sdk and run it from the command line.

The entry point project is StageRaceFantasy.Api.  In Visual Studio:
- Ensure StageRaceFantasy.Api is selected as the startup project
- Hit F5
- This starts debugging and should automatically open the application in a browser.

#### A note on the Database
The project uses a local `(localdb)\\MSSQLLocalDB` database server and the database is created and migrated when you start the project.  If you are not using Visual Studio or this does not work then open up _\StageRaceFantasy.Api\appsettings.Development.json_ and update `ConnectionStrings.SqlDatabase` to point at an SQL Server that you have availale.


## References
Some references that I have learned and borrowed from:
- [Clean Architecture Template](https://github.com/jasontaylordev/CleanArchitecture)
- [Clean Testing Example](https://github.com/jasontaylordev/CleanTesting)
- [Mediatr validation without exceptions](https://medium.com/the-cloud-builders-guild/validation-without-exceptions-using-a-mediatr-pipeline-behavior-278f124836dc)