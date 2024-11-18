using System.Text;
using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Database.Helpers;
using Backend.Hubs;
using Backend.Middlewares;
using Backend.Services;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSignalR()
    .AddJsonProtocol(p =>
    {
        p.PayloadSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddHttpLogging(o => {});

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<FootballerService>();

var app = builder.Build();


app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapHub<FootballersHub>("/footballersHub");

app.Run();