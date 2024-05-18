using MilkyCow.BusinessLayer.Abstact.IAbstractService;
using MilkyCow.EntityLayer.Concrete;

namespace MinimalApi.Endpoints.ProductEndpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/MinimalApiCreateProduct", (IProductService _productService, Product product) =>
            {
                _productService.Add(product);
                return Results.Ok(product);
            });
        }
    }
}
