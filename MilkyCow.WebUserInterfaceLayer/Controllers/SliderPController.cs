using Microsoft.AspNetCore.Mvc;
using MilkyCow.WebUserInterfaceLayer.Dtos;
using Newtonsoft.Json;

namespace MilkyCow.WebUserInterfaceLayer.Controllers
{
    public class SliderPController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public SliderPController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            #region option 1
            //var baseUrl = _configuration["AppSettings:BaseApiUrl"];
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync($"{baseUrl}Sliders/GetAllSliders");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            //    return View(values);
            //}
            //return View();
            #endregion

            #region option 2
            //var baseUrl = _configuration["AppSettings:BaseApiUrl"];
            //var client = _httpClientFactory.CreateClient();

            //var values = await client.GetFromJsonAsync<List<ResultSliderDto>>($"{baseUrl}Sliders/GetAllSliders");
            //return View(values ?? new List<ResultSliderDto>()); // Return an empty list if values are null
            #endregion

            #region option 3
            //var baseUrl = _configuration["AppSettings:BaseApiUrl"];

            //var values = await _httpClientFactory.CreateClient()
            //    .GetFromJsonAsync<List<ResultSliderDto>>($"{baseUrl}Sliders/GetAllSliders");

            //return View(values ?? new List<ResultSliderDto>());
            #endregion

            var api1 = _configuration["AppSettings:BaseApiUrl"];
            var values1 = await _httpClientFactory.CreateClient().GetFromJsonAsync<List<ResultSliderDto>>($"{api1}Sliders/GetAllSliders");
            return View(values1 ?? new List<ResultSliderDto>());
        }
    }
}
