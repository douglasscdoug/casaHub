var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline HTTP

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();