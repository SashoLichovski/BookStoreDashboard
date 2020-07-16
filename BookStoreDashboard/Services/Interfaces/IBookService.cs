using BookStoreDashboard.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Requests for all books from Web API
        /// </summary>
        /// <returns>List<BookDto></returns>
        Task<List<BookDto>> GetAll();
        Task<BookDto> GetById(int bookId);
        Task<string> Update(BookDto book);
        void Create(BookDto book);
        Task UpdateIsDeleted(int bookId, bool status);
    }
}
