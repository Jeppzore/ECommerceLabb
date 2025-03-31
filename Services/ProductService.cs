using System.Net.Http.Json;
using System.Text.Json;
using ECommerceLabb.Models;

namespace ECommerceLabb.Services

{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            // Read API URL from appsettings.json
            _apiBaseUrl = _configuration["ApiBaseUrl"]!;
        }

        public async Task<List<Product>?> GetproductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>($"{_apiBaseUrl}/products");
        }

		public async Task<Product> GetproductByNameAsync(string name)
		{
            try
            {
			    return await _httpClient.GetFromJsonAsync<Product>($"{_apiBaseUrl}/products/name/{name}");
            }
            catch (HttpRequestException ex)
            {
				Console.WriteLine($"Error fetching product: {ex.Message}");
				return null!;
			}
		}

		public async Task<bool> DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/products/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(string id, Product updatedProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/products/{id}", updatedProduct);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                Console.WriteLine($"HttpClient BaseAddress: {_httpClient.BaseAddress}");
                Console.WriteLine($"Sending request to API: {JsonSerializer.Serialize(product)}");

                var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/products", product);

                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling API: {ex.Message}");
                return false;
            }
        }
    }
}
