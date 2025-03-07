using FastEndpoints;
using FastEndpoints.Swagger;
using fastEndPointsAPIs.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "FastEndPoints API";
            s.Version = "v1";
        };
    }
    
    ); 
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

var app  = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen(); // enables the swagger ui for visualizing and testing

app.Run();


