using BookStoreDashboard.Models.Book;
using BookStoreDashboard.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<List<BookDto>> GetAll()
        {
            HttpClient httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync("https://localhost:44345/api/Book");

            var response = await httpResponse.Content.ReadAsStringAsync();

            var books = JsonConvert.DeserializeObject<List<BookDto>>(response);

            return books;
        }
    }
}

