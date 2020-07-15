using BookStoreDashboard.Models.Book;
using BookStoreDashboard.Repositories.Interfaces;
using BookStoreDashboard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        
        public Task<List<BookDto>> GetAll()
        {
            return bookRepo.GetAll();
        }
    }
}
