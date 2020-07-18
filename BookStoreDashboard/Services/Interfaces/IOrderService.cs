using BookStoreDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAll();
        Task<string> Update(int orderId, EnumStatus status);
    }
}
