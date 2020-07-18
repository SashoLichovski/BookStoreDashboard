using BookStoreDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAll();
        Task<bool> Update(UpdateOrderDto updateOrderDto);
    }
}
