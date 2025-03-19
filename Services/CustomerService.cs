using ECommerceLabb.Models;
using System.Net.Http.Json;


namespace ECommerceLabb.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public CustomerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            // Read API URL from appsettings.json
            _apiBaseUrl = _configuration["ApiBaseUrl"]!;
        }

        public async Task<List<Customer>?> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>($"{_apiBaseUrl}/customers");
        }
    }
}
