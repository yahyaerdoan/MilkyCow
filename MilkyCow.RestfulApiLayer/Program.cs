using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Concrete.Context;
using System.Text.Json.Serialization;
using MilkyCow.BusinessLayer.Extentensions;
using MilkyCow.DataTransferObjectLayer.AutoMapper.EntityDtoMappers;
using MilkyCow.BusinessLayer.Abstract.IServiceManager;
using MilkyCow.BusinessLayer.Concrete.ServiceManager;
using System;
using MilkyCow.DataTransferObjectLayer.Concrete.TeamMemberDtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbContext, MilkyCowDbContext>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped(provider =>
    new Lazy<IServiceManager>(() => provider.GetRequiredService<IServiceManager>()));
builder.Services.ContainerDependencyInjection();
builder.Services.AddAutoMapper(typeof(MappingProfile));


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
