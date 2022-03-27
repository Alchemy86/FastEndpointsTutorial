global using FastEndpoints;
global using FastEndpoints.Validation;

using FastEndpoints.Swagger;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddFastEndpoints()
    .AddSwaggerDoc()
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();

// Add Swagger Docs
app.UseSwaggerUi3(c => c.ConfigureDefaults());

await DB.InitAsync(database: "MyDatabase", host: "localhost", port: 27017);

app.Run();