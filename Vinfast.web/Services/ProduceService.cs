using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vinfast.models;
using Microsoft.AspNetCore.Components;

namespace Vinfast.web.Services
{
    public class ProduceService : IProduceService
    {
        private readonly HttpClient httpClient;
        public ProduceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await httpClient.GetJsonAsync<Product[]>("api/product");
        }
        public async Task<Product> GetProduct(int id)
        {
            return await httpClient.GetJsonAsync<Product>($"api/product/{id}");
        }
    }
}
