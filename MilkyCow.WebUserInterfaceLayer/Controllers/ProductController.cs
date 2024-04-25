using Microsoft.AspNetCore.Mvc;
using MilkyCow.WebUserInterfaceLayer.Dtos;
using Newtonsoft.Json;

namespace MilkyCow.WebUserInterfaceLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44367/api/Product");
            if (responseMessage.IsSuccessStatusCode) 
            { 
                var jonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jonData);
                return View(values);
            }
            return View();
        }
    }
}