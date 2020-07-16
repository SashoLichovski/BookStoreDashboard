using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreDashboard.Models;
using BookStoreDashboard.Models.Book;
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

        public async Task<IActionResult> Edit(int bookId)
        {
            var book = await bookService.GetById(bookId);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDto book)
        {
            var result = await bookService.Update(book);
            return RedirectToAction("ActionMessage", new { Message = result });
        }

        public IActionResult Delete(int bookId)
        {
            bookService.Delete(bookId);
            return RedirectToAction("ActionMessage", new { Message = "Book successfully removed from user display" });
        }

        public IActionResult ActionMessage(ActionMessage actionMessage)
        {
            return View(actionMessage);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookDto book)
        {
            if (ModelState.IsValid)
            {
                bookService.Create(book);
                return RedirectToAction("ActionMessage", new { Message = "Book successfully created" });
            }
            return View(book);
        }
    }
}
