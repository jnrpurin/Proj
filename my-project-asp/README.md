# my-dotnet-core-project

This is a sample project developed in .NET Core to manage users.

## Project Structure

- **Controllers**: Contains the controllers that manage the requests.
    - `UsersController.cs`: Controller for the users page.

- **Services**: Contains the services classes that represent the business.
    - `UserService.cs`: Class that represents a user services.

- **Repository**: Contains the classes that represent the data from database.
    - `UserRepository.cs`: Class that represents a user repository and methods to handle user data.

- **Models**: Contains the model classes that represent the data.
    - `User.cs`: Class that represents a user in the system.

- **Views**: Contains the Razor views that render the application pages.
    - `Users/Index.cshtml`: View for the home page.

- **Configurations**:
    - `appsettings.json`: Contains the application settings, such as connection strings.
    
- **Main Files**:
    - `Program.cs`: Entry point of the application.
    - `Startup.cs`: Configuration of services and request pipeline.
    - `my-dotnet-core-project.csproj`: Project file that contains dependency information.