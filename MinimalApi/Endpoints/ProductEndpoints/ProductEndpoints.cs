using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MinimalApi.Endpoints.ProductEndpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/getproduct/{id}", (string id, IProductService _productService) => {

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

            endpoints.MapGet("/getallproducts", (IProductService productService) =>
            {
                var products = productService.GetAll();
                return Results.Ok(products);
            });           

            endpoints.MapPost("/createproduct", (IProductService _productService, Product product) =>
            {
                _productService.Add(product);
                return Results.Ok(product);
            });

            endpoints.MapPut("/updateproduct/{id}", (int id, IProductService _productService, Product updatedProduct) =>
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

            endpoints.MapDelete("/deleteproduct/{id}", (int id, IProductService _productService) =>
            {
                var existingProduct = _productService.GetById(id);
                if (existingProduct == null)
                {
                    return Results.BadRequest("Invalid product ID. Product does not exist.");
                }
                _productService.Delete(existingProduct.ProductId);
                return Results.Ok(existingProduct);
            });

            endpoints.MapPost("/deletemultipleproducts/{ids}", (string ids, IProductService _productService) =>
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
        }
    }
}
