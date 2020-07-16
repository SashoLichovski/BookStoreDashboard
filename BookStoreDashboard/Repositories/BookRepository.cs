using BookStoreDashboard.Models.Book;
using BookStoreDashboard.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Create(BookDto book)
        {
            HttpClient httpRequest = new HttpClient();
            httpRequest.PostAsJsonAsync("https://localhost:44345/api/Book", book);
        }

        public async Task<List<BookDto>> GetAll()
        {
            HttpClient httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync("https://localhost:44345/api/Book");
            var response = await httpResponse.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookDto>>(response);

            var httpResponse2 = await httpRequest.GetAsync("https://localhost:44345/api/Book/deleted");
            var response2 = await httpResponse2.Content.ReadAsStringAsync();
            var deletedBooks = JsonConvert.DeserializeObject<List<BookDto>>(response2);

            foreach (var book in deletedBooks)
            {
                books.Add(book);
            }

            return books;
        }

        public async Task<BookDto> GetById(int bookId)
        {
            HttpClient httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync($"https://localhost:44345/api/Book/{bookId}");

            var response = await httpResponse.Content.ReadAsStringAsync();

            var book = JsonConvert.DeserializeObject<BookDto>(response);

            return book;
        }

        public async Task<string> Update(BookDto book)
        {
            HttpClient httpRequest = new HttpClient();
            
            var httpResponse = await httpRequest.PutAsJsonAsync<BookDto>("https://localhost:44345/api/Book", book);
            if (httpResponse.IsSuccessStatusCode)
            {
                return "Book successfully updated";
            }
            else
            {
                return "Update failed";
            }
        }
    }
}

