using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreDashboard.Models;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreDashboard.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task<IActionResult> Overview()
        {
            var orders = await orderService.GetAll();
            return View(orders);
        }

        public async Task<IActionResult> Update(int orderId, EnumStatus status)
        {
            var result = await orderService.Update(orderId, status);
            return RedirectToAction("ActionMessage", "Home", new { Message = result });
        }
    }
}
