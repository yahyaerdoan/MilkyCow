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
            var response = await _httpClientFactory.CreateClient().GetFromJsonAsync<List<TEntity>>($"{configuration}/{link}");
            return (response ?? new List<TEntity>());
        }

        public async Task<List<TEntity>> GetListByIdAsync(string link, int id)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var response = await _httpClientFactory.CreateClient().GetFromJsonAsync<List<TEntity>>($"{configuration}/{link}/{id}");
            return (response ?? new List<TEntity>());
        }

        public async Task<TEntity> GetByIdAsync(string link, int id)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var response = await _httpClientFactory.CreateClient().GetFromJsonAsync<TEntity>($"{configuration}/{link}/{id}");
            return response ?? null;
        }

        public async Task<int> PostAsync(string link, object classDto)
        {
            var configuration = _configuration["AppSettings:BaseApiUrl"];
            var client = _httpClientFactory.CreateClient();         
            var responseMessage = await client.PostAsJsonAsync($"{configuration}/{link}", classDto);
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
            var responseMessage = await client.PutAsJsonAsync($"{configuration}/{link}/", classDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteAsync(string link, int id)
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
