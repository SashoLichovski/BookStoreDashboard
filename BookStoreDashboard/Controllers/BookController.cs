using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreDashboard.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Overview()
        {
            var books = await bookService.GetAll();
            return View(books);
        }
    }
}
