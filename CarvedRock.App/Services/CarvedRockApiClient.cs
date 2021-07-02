using CarvedRock.App.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarvedRock.App.Services
{
    public class CarvedRockApiClient : ICarvedRockApiClient
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public CarvedRockApiClient(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
            this.client.BaseAddress = new Uri(configuration.GetValue<string>("CarvedRockApiUrl"));
        }

        public async Task<List<Product>> GetProducts()
        {
            return await client.GetFromJsonAsync<List<Product>>("product");
        }
    }
}
