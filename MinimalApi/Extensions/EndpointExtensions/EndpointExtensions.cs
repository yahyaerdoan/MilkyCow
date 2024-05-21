using MilkyCow.MinimalApi.Endpoints.CategoryEndpoints;
using MinimalApi.Endpoints.ProductEndpoints;

namespace MilkyCow.MinimalApi.Extensions.EndpointExtensions
{
    public static class EndpointExtensions
    {
        public static void MapAllEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapProductEndpoints();
            // Add calls to other endpoint mapping methods here, e.g.:
            // endpoints.MapOrderEndpoints();
            // endpoints.MapCustomerEndpoints();
        }
    }
}
 