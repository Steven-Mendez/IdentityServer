using System.Reflection;
using IdentityServer.Application.DependencyInjection;
using IdentityServer.Infrastructure.DependencyInjection;
using IdentityServer.Presentation.DependencyInjections;
using IdentityServer.Presentation.Middlewares.GlobalError;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(
    swaggerGenOptions =>
    {
        swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityServer API", Version = "v1" });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        swaggerGenOptions.IncludeXmlComments(xmlPath);
    });
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddSettings(configuration);
builder.Services.AddHttpClient();

var app = builder.Build();

// Configures Swagger UI if the application is in development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensures the IdentityServer database is migrated to the latest version on startup.
app.Services.EnsureIdentityServerDatabaseMigrated();

// Adds middleware for redirecting HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Adds authorization middleware to the request pipeline.
app.UseAuthorization();

// Adds a custom global error handling middleware to the request pipeline.
app.UseMiddleware<GlobalErrorMiddleware>();

// Maps controller actions to routes.
app.MapControllers();

app.Run();