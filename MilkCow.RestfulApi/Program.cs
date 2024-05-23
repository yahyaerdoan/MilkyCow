using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.BusinessLayer.Concrete.ConcreteManager;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.Context;
using MilkyCow.DataAccessLayer.Concrete.EntityFramework;
using MilkyCow.EntityLayer.Concrete;
using System.Text.Json.Serialization;
using MilkyCow.BusinessLayer.Extentensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbContext, MilkyCowDbContext>();
builder.Services.ContainerDependencyInjection();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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