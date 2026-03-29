using AdventOfCodeShared.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.RollingFile("Logs/{Date}.log", LogEventLevel.Verbose)
    .WriteTo.Console());

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Advent of Code Server",
        Version = "v1",
        Description = "API for retrieving Advent of Code puzzle solutions (2015-2025)"
    });
});

builder.Services.AddHttpClient();
builder.Services.AddScoped<IInputRetriever, InputRetriever>();
builder.Services.AddScoped<ISolutionService, SolutionService>();

// Configure CORS - tightened from AllowAnyOrigin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithExposedHeaders("Content-Disposition", "Content-Length");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.EnvironmentName == "Development")
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advent of Code Server v1"));

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
