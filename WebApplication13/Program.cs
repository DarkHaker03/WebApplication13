using Microsoft.EntityFrameworkCore;
using WebApplication6.src.Configurations;
using Microsoft.AspNetCore.Http.Json;
using System.Net;
using WebApplication6.src.Features.Authorization.Dto;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<MySqlDbContext>(opts =>
{
    var connectionString = "server=bd;port=3306;username=root;password=root;database=trialbd";
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseRouting();


var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<MySqlDbContext>();
context.Database.Migrate();

app.Run();
