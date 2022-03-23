global using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddFastEndpoints()
    .AddSwaggerDoc();

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();

// Add Swagger Docs
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();