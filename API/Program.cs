using System.Reflection;
using Business;
using Business.Application.Behaviors;
using Business.Application.Commands.Task.Add;
using Infrastructure.Persistence.DbContext;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
Startup startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.Run();