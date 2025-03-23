using System.Net.Http.Json;
using ECommerceLabb.Models;

namespace ECommerceLabb.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"]!;
        }

        public async Task<List<Order>?> GetOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>($"{_apiBaseUrl}/orders");
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/orders", order);
            return response.IsSuccessStatusCode;
        }
    }
}
