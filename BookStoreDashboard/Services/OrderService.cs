using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using BookStoreDashboard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async Task<List<OrderDto>> GetAll()
        {
            return await orderRepo.GetAll();
        }

        public async Task<string> Update(int orderId, EnumStatus status)
        {
            var updateOrderDto = new UpdateOrderDto()
            {
                OrderId = orderId,
                Status = status
            };
            if (await orderRepo.Update(updateOrderDto))
            {
                return $"Order has been successfully updated to {status}";
            }
            else
            {
                return "Order not found. Please contact your IT representative";
            }
        }
    }
}
