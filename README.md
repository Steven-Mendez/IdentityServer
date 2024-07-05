# 1. IdentityServer

IdentityServer is my personal project, serving as a hands-on exploration and learning journey in various aspects of software development, particularly within the .NET ecosystem. This endeavor provides a practical platform to delve into advanced concepts and gain expertise in cutting-edge technologies.

An Identity Server, also known as an Identity Provider (IdP), is a crucial component in modern authentication and authorization systems. It is responsible for managing and verifying user identities within a computer system or network. In the context of this project, IdentityServer plays a central role in handling authentication, authorization, and access control.

## 1.1. Table of Contents

- [1. IdentityServer](#1-identityserver)
  - [1.1. Table of Contents](#11-table-of-contents)
  - [1.2. Project Structure](#12-project-structure)
  - [1.3. Getting Started](#13-getting-started)
  - [1.4. Configuration](#14-configuration)
  - [1.5. Building and Testing](#15-building-and-testing)
  - [1.6. Learning Outcomes](#16-learning-outcomes)
  - [1.7. Contributing](#17-contributing)

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
- The admin user credentials are `"email": admin@admin.com` and `"password": P@ssw0rd!`.

## 1.4. Configuration

In the project, configuration settings are managed through the `appsettings.json` file. For the development environment, `appsettings.Development.json` is used. Here is an example configuration file, `appsettings.Example.json`, along with an explanation of each setting:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "IdentityServerSettings": {
    "Url": "http://your-identityserver-url.com"
  },
  "ConnectionStrings": {
    "IdentityServerConnection": "Server=your-server-name;Database=your-database-name;User Id=your-username;Password=your-password;"
  },
  "JsonWebTokenSettings": {
    "Issuer": "https://your-issuer-url.com",
    "Audience": "https://your-audience-url.com",
    "SigningKey": "your-base64-encoded-signing-key",
    "ExpirationMinutes": 10
  },
  "AzureAd": {
    "ClientId": "your-azure-ad-client-id",
    "TenantId": "your-azure-ad-tenant-id",
    "ClientSecret": "your-azure-ad-client-secret",
    "RedirectUrl": "http://your-identityserver-url.com/api/Authentication/Oauth2.0/azure-ad/callback"
  }
}

```

**Explanation of Settings:**

1. **Logging:**
   - `LogLevel`: Specifies the logging levels. `Default` is set to `Information` and `Microsoft.AspNetCore` is set to `Warning` to reduce verbosity from ASP.NET Core framework.
2. **AllowedHots:**
   - Allows setting up a list of allowed hostnames. `*` allows all hosts.
3. **IdentityServerSettings:**
   - `Url`: The URL where the IdentityServer is hosted.
4. **ConnectionStrings:**
   - `IdentityServerConnection`: Connection string to the SQL Server database used by IdentityServer. Replace placeholders with your server name, database name, username, and password.
5. **JsonWebTokenSettings:**
   - `Issue`: URL of the token issuer.
   - `Audience`: URL of the token audience.
   - `SigningKey`: Base64-encoded signing key used for token signing. Replace with your actual signing key.
   - `ExpirationMinutes`: Token expiration time in minutes.
6. **AzureAd:**
   - `ClientId`: The client ID of the Azure AD application.
   - `TenantId`: The tenant ID or customer ID for Azure AD.
   - `ClientSecret`: The client secret for Azure AD.
   - `RedirectUrl`: The URL to which Azure AD redirects after authentication. Replace with your actual URL.

## 1.5. Building and Testing

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

## 1.6. Learning Outcomes

This personal project serves as a rich learning opportunity, providing hands-on experience and insights into the following key areas:

.NET 8.0 SDK
Entity Framework Core
Dependency Injection
Unit Testing
Web API Development
Security Enhancements
Embarking on this journey, I anticipate gaining valuable knowledge and honing my skills in these advanced technologies.

## 1.7. Contributing

I do not accept contributions to this project. It is a personal project for learning purposes only. However, you are welcome to fork the repository and use it as a reference for your own projects.
