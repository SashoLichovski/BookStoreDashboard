using BookStoreDashboard.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAll();
    }
}
