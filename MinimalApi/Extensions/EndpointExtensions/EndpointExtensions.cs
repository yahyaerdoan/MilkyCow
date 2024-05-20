using MinimalApi.Endpoints.ProductEndpoints;

namespace MilkyCow.MinimalApi.Extensions.EndpointExtensions
{
    public static class EndpointExtensions
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var productEndpointMapper = endpoints.ServiceProvider.GetRequiredService<ProductEndpoints>();
            productEndpointMapper.MapEndpoints(endpoints);
        }
    }
    }
}
