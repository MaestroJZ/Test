using HCTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CategoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CategoryContext")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
