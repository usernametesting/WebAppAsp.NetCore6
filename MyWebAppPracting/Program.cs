using Microsoft.EntityFrameworkCore;
using MyWebAppPracting.Controllers;
using MyWebAppPracting.Models;
using MyWebAppPracting.Models.ModelsMyFirstCodeDatabase;
using MyWebAppPracting.Models.ModelsUser;
using MyWebAppPracting.Reposters;
using MyWebAppPracting.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<usersContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddTransient(typeof(IStudentReposteriGeneric<>),typeof(StudentReposteriGeneric<>));
builder.Services.AddScoped<UnitOfWork>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
