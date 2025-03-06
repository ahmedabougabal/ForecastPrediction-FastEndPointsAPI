using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(); 
builder.Services.AddAuthorization();

var app  = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen(); // enables the swagger ui for visualizing and testing

app.Run();


