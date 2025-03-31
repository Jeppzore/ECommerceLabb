using ECommerceLabb.Models;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


namespace ECommerceLabb.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        //private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public CustomerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Read API URL from appsettings.json
            _apiBaseUrl = configuration["ApiBaseUrl"] ?? throw new Exception("ApiBaseUrl is missing from configuration!");
        }

        public async Task<List<Customer>?> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>($"{_apiBaseUrl}/customers");
        }

        public async Task<Customer> GetcustomerByEmailAsync(string email)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Customer>($"{_apiBaseUrl}/customers/{email}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching product: {ex.Message}");
                return null!;
            }
        }

        public async Task<bool> UpdateCustomerAsync(string email, Customer updatedCustomer)
		{
			var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/customers/{email}", updatedCustomer);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> RegisterCustomerAsync(Customer customer)
        {
            try
            {
                Console.WriteLine($"HttpClient BaseAddress: {_httpClient.BaseAddress}");
                Console.WriteLine($"Sending request to API: {JsonSerializer.Serialize(customer)}");
                
                var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/customers", customer);

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
