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

        public void Create(BookDto book)
        {
            bookRepo.Create(book);
        }

        public async Task Delete(int bookId)
        {
            var book = await bookRepo.GetById(bookId);
            book.IsDeleted = true;
            await bookRepo.Update(book);
        }

        public Task<List<BookDto>> GetAll()
        {
            return bookRepo.GetAll();
        }

        public Task<BookDto> GetById(int bookId)
        {
            return bookRepo.GetById(bookId);
        }

        public Task<string> Update(BookDto book)
        {
            return bookRepo.Update(book);
        }
    }
}
