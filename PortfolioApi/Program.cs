using Npgsql.EntityFrameworkCore;
using Portfolio.Services;
using Portfolio.Models;
using Supabase;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.HttpsPolicy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the user-secrets
if (builder.Environment.IsDevelopment())
{
    // builder.Configuration.AddUserSecrets<Program>();
    Debug.WriteLine("Loading secrets from secrets.json file for development.");
    builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);
}

// Supabase Api
try 
{
    var supabaseSection = builder.Configuration
        .GetSection("Supabase");
    var url = supabaseSection["BaseUrl"];
    var key = supabaseSection["ApiKey"];
    
    var options = new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
        // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
    };
    // Note the creation as a singleton.
    builder.Services.AddSingleton(provider => new Supabase.Client(url!, key, options));
}
catch (Exception ex)
{
    Debug.WriteLine($"Error while initializing Supabase client: {ex.Message}");
}

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClients", policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200",
            "https://afrowave.netlify.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.Configure<HttpsRedirectionOptions>(options =>
{
    options.HttpsPort = 7201;
});


//Mailkit
builder.Services.AddTransient<MailKitSender>();

// Controller
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS before routing ["AllowAngularClients"]
app.UseCors("AllowAngularClients");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// For controller
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
