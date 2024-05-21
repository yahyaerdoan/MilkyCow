using MilkyCow.WebUserInterfaceLayer.Dtos;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume
{
    public class DynamicConsume<TEntity> where TEntity : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public DynamicConsume(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<TEntity>> GetListAsync(string link)
        {
            var configuration  = _configuration["AppSettings:BaseApiUrl"];
            var response = await _httpClientFactory.CreateClient().GetFromJsonAsync<List<TEntity>>($"https://localhost:44367/api/{link}");
            return (response ?? new List<TEntity>());
        }
        public async Task<TEntity> GetById(int id, string link)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var response = await _httpClientFactory.CreateClient().GetFromJsonAsync<TEntity>($"{configuration}/{link}");
            return response ?? null;
        }

        public async Task<int> PostAsync(string link, object classDto)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(classDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{configuration}/{link}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> PutAsync(string link, object classDto)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(classDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{configuration}/{link}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteAsync(int id, string link)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var responseMessage = await _httpClientFactory.CreateClient().DeleteAsync($"{configuration}/{link}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }
    }
}
