# 1. IdentityServer

IdentityServer is my personal project, serving as a hands-on exploration and learning journey in various aspects of software development, particularly within the .NET ecosystem. This endeavor provides a practical platform to delve into advanced concepts and gain expertise in cutting-edge technologies.

## 1.1. Table of Contents

- [1. IdentityServer](#1-identityserver)
  - [1.1. Table of Contents](#11-table-of-contents)
  - [1.2. Project Structure](#12-project-structure)
  - [1.3. Getting Started](#13-getting-started)
  - [1.4. Building and Testing](#14-building-and-testing)
  - [1.5. Learning Outcomes](#15-learning-outcomes)
  - [Contributing](#contributing)

## 1.2. Project Structure

The project follows the principles of Clean Architecture, ensuring a separation of concerns and maintainability. It is structured into the following layers:

- **IdentityServer.Domain:** Core domain logic and entities.
- **IdentityServer.Infrastructure:** Data persistence and infrastructure-related tasks.
- **IdentityServer.Application:** Application logic and interfaces.
- **IdentityServer.Presentation:** Presentation layer, including the web API.
- **IdentityServer.InfrastructureTests:** Unit tests specifically for the Infrastructure project.

## 1.3. Getting Started

To initiate your journey with IdentityServer, follow these steps:

1. **Set Up the Development Environment:**
   - Ensure you have the .NET 8.0 SDK installed on your machine. Download it from the [official .NET website](https://dotnet.microsoft.com/download).

2. **Clone the Repository:**
   - Clone the project repository to your local machine using Git.

3. **Restore NuGet Packages:**
   - Navigate to the project's root directory in your terminal and run:

     ```bash
     dotnet restore
     ```

4. **Build the Project:**
   - Execute the following command to build the project:

     ```bash
     dotnet build
     ```

5. **Set Up the Database:**
   - Update the connection string in `appsettings.Development.json` to point to your SQL Server instance.
   - Run database migrations to create the database schema.

6. **Run the Project:**
   - Launch the project with:

     ```bash
     dotnet run
     ```

   - Access the application at the URLs specified in `launchSettings.json`.

7. **Navigate to the Swagger UI:**
   - Open a web browser and visit `/swagger` to interact with the API endpoints.

**Additional Notes:**

- Check `.gitignore` to understand which files and directories are not tracked by Git.

## 1.4. Building and Testing

To build and test your project, use the following commands in the terminal:

1. **Build the Solution:**

   ```bash
   dotnet build
    ```

2. **Run the Tests::**

   ```bash
   dotnet test
   ```

This command triggers the execution of all tests across the solution, including the tests within the `IdentityServer.InfrastructureTests` project located in the `IdentityServer.InfrastructureTests.csproj`.

These commands streamline the build and testing processes, allowing you to compile the solution seamlessly and validate its integrity through a comprehensive suite of tests. The `IdentityServer.InfrastructureTests` project plays a pivotal role in ensuring the reliability and correctness of the infrastructure components within your IdentityServer solution.

## 1.5. Learning Outcomes

This personal project serves as a rich learning opportunity, providing hands-on experience and insights into the following key areas:

.NET 8.0 SDK
Entity Framework Core
Dependency Injection
Unit Testing
Web API Development
Security Enhancements
Embarking on this journey, I anticipate gaining valuable knowledge and honing my skills in these advanced technologies.

## Contributing

I do not accept contributions to this project. It is a personal project for learning purposes only. However, you are welcome to fork the repository and use it as a reference for your own projects.
