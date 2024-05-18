using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.BusinessLayer.Concrete.ConcreteManager;
using MilkyCow.DataAccessLayer.Abstact.IAbstractDal;
using MilkyCow.DataAccessLayer.Concrete.EntityFramework;
using MinimalApi.Endpoints.ProductEndpoints;
using MilkyCow.BusinessLayer.Extentensions;
using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Concrete.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext, MilkyCowDbContext>();

builder.Services.ContainerDependencyInjection();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapProductEndpoints();

app.Run();
