using IdentityServer.Application.DependencyInjection;
using IdentityServer.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.EnsureIdentityServerDatabaseMigrated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
