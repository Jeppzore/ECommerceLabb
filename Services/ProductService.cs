﻿using System.Net.Http.Json;
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
    }
}
