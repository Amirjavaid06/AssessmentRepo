using Application.Task.Queries;
using AutoMapper;
using DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


//MVC configuration
builder.Services.AddControllersWithViews();

//auto mapper and mediator configurtaion
builder.Services.AddAutoMapper(typeof(Program), typeof(GetTaskByIdQuery));
builder.Services.AddMediatR(typeof(GetTaskByIdQuery));
//sql server configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
