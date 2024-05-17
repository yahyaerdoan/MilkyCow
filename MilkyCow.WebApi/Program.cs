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

app.MapGet("/MinimalApiProducts", (IProductService _productService) =>
{
	return _productService.GetAll().ToList();
});

app.MapGet("/MinimalApiProducts/{id}", (string id, IProductService _productService) => {

	if (!int.TryParse(id, out int productId) || productId <= 0)
	{
		return Results.BadRequest("Invalid ID format. ID must be a numeric value and a positive integer.");
    }
	var product = _productService.GetById(productId);
	if (product != null)
	{
		return Results.Ok(product);
	}
	else
	{
        return Results.NotFound($"Product with ID {productId} not found.");
    }
});

app.MapPost("/MinimalApiCreateProduct", (IProductService _productService, Product product) =>
{
    _productService.Add(product);

    return Results.Ok(product);
});

app.MapPut("/MinimalApiUpdateProduct/{id}", (int id, IProductService _productService, Product updatedProduct) =>
{
    var existingProduct = _productService.GetById(id);
    if (existingProduct == null)
    {
        return Results.BadRequest("Invalid product ID. Product does not exist.");
    }
    if (id != updatedProduct.ProductId)
    {
        return Results.BadRequest("Invalid category ID. Category does not match the product's category.");
    }
    _productService.Update(existingProduct);
    return Results.Ok(existingProduct);
});

app.MapDelete("/MinimalApiDeleteProduct/{id}", (int id, IProductService _productService) =>
{
    var existingProduct = _productService.GetById(id);
    if (existingProduct == null)
    {
        return Results.BadRequest("Invalid product ID. Product does not exist.");
    }
    _productService.Delete(existingProduct.ProductId);
    return Results.Ok(existingProduct);
});

app.MapPost("/MinimalApiMultipleDeleteProducts/{ids}", (string ids, IProductService _productService) =>
{
    // Split the comma-separated string of IDs into an array of integers
    var idArray = ids.Split(',').Select(int.Parse).ToArray();

    foreach (var id in idArray)
    {
        var existingProduct = _productService.GetById(id);
        if (existingProduct == null)
        {
            return Results.BadRequest($"Invalid product ID {id}. Product does not exist.");
        }
        _productService.Delete(existingProduct.ProductId);
    }
    return Results.Ok($"Deleted product ID {ids}");
});
app.Run();