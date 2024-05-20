using MinimalApi.Endpoints.ProductEndpoints;
using MilkyCow.BusinessLayer.Extentensions;
using Microsoft.EntityFrameworkCore;
using MilkyCow.DataAccessLayer.Concrete.Context;
using Microsoft.OpenApi.Models;
using MilkyCow.MinimalApi.Extensions.EndpointExtensions;

var builder = WebApplication.CreateBuilder(args);
#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
#endregion

builder.Services.AddDbContext<DbContext, MilkyCowDbContext>();
builder.Services.ContainerDependencyInjection();



var app = builder.Build();
#region Swagger
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI at the app's root
    });
}
app.UseHttpsRedirection();
#endregion

app.MapAllEndpoints();
app.Run();
