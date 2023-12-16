using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyWebAppPracting.Controllers;
using MyWebAppPracting.MiddleWares;
using MyWebAppPracting.Models;
using MyWebAppPracting.Models.ModelsMyFirstCodeDatabase;
using MyWebAppPracting.Models.ModelsUser;
using MyWebAppPracting.Reposters;
using MyWebAppPracting.UnitOfWorks;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File
    (
          Path.Combine("D:\\LogFiles", "Application", "foo.txt"),
          rollingInterval: RollingInterval.Day,
          fileSizeLimitBytes: 10 * 1024 * 1024,
          retainedFileCountLimit: 30,
          rollOnFileSizeLimit: true,
          shared: true,
          flushToDiskInterval: TimeSpan.FromSeconds(2)
    )
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<usersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddTransient(typeof(IStudentReposteriGeneric<>),typeof(StudentReposteriGeneric<>));
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SignInKey"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "example",
            ValidAudience = "example",
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Host.UseSerilog();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddSerilog();
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<JwtMiddleWare>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
