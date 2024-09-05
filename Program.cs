using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Flanimas___Backend.Models.Identity;
using Flanimas___Backend.Models;
using Flanimas___Backend.Controllers;
var builder = WebApplication.CreateBuilder(args);
var connectionString = System.Environment.GetEnvironmentVariable("DB_URL");
builder.Services.AddDbContext<FlanimasContext>(options =>
    options.UseNpgsql(connectionString ?? throw new InvalidOperationException("Connection string 'FlanimasContext' not found.")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FlanimasContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapCustomIdentityApi<User>();

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
