using MilkyCow.BusinessLayer.Abstact.IAbstractService;

namespace MilkyCow.MinimalApi.Endpoints.CategoryEndpoints
{
    public class CategoryEndpoints
    {
        private readonly ICategoryService _categoryService;

        public CategoryEndpoints(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void MapCategoryEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/getproduct/{id}", async context =>
            {
                string? id = context.Request.RouteValues["id"] as string;
                if (!int.TryParse(id, out int productId) || productId <= 0)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid ID format. ID must be a numeric value and a positive integer.");
                    return;
                }
                var product = _categoryService.GetById(productId);
                if (product != null)
                {
                    await context.Response.WriteAsJsonAsync(product);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync($"Product with ID {productId} not found.");
                }
            });

            // Define other endpoint mappings similarly...
        }
    }
}
