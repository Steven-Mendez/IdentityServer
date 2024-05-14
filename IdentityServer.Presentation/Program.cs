using IdentityServer.Application.DependencyInjection;
using IdentityServer.Infrastructure.DependencyInjection;
using IdentityServer.Presentation.DependencyInjections;
using IdentityServer.Presentation.Middlewares.GlobalError;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddSettings(configuration);
builder.Services.AddHttpClients();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.EnsureIdentityServerDatabaseMigrated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalErrorMiddleware>();

app.MapControllers();

app.Run();