using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<OrderDto>> GetAll()
        {
            HttpClient httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync("https://localhost:44345/api/Order");
            var response = await httpResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderDto>>(response);

            return orders;
        }

        public async Task<bool> Update(UpdateOrderDto updateOrderDto)
        {
            HttpClient httpRequest = new HttpClient();
            var httpResponse = await httpRequest.PutAsJsonAsync<UpdateOrderDto>("https://localhost:44345/api/Order", updateOrderDto);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
