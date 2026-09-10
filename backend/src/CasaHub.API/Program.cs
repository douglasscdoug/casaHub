using CasaHub.API.Extensions;
using CasaHub.Application;
using CasaHub.Infrastructure;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/casahub-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CasaHubPolicy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "https://casahub.seudominio.com"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("CasaHubPolicy");

app.UseApiMiddlewares();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();