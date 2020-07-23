using BookStoreDashboard.Models.Book;
using BookStoreDashboard.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string bookStoreBaseUrl;
        private readonly string defaultAuthSchema;
        private readonly string apiKey;
        public BookRepository(IConfiguration config)
        {
            bookStoreBaseUrl = config["BookStoreApi:BaseUrl"];
            defaultAuthSchema = config["BookStoreApi:AuthSchema"];
            apiKey = config["BookStoreApi:ApiKey"];
        }

        public void Create(BookDto book)
        {
            HttpClient httpRequest = new HttpClient();

            httpRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(defaultAuthSchema, apiKey);

            httpRequest.PostAsJsonAsync($"{bookStoreBaseUrl}/api/Book", book);
        }

        public async Task<List<BookDto>> GetAll()
        {
            HttpClient httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync($"{bookStoreBaseUrl}/api/Book");
            var response = await httpResponse.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookDto>>(response);

            var httpResponse2 = await httpRequest.GetAsync($"{bookStoreBaseUrl}/api/Book/deleted");
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

            httpRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(defaultAuthSchema, apiKey);

            var httpResponse = await httpRequest.PutAsJsonAsync<BookDto>($"{bookStoreBaseUrl}/api/Book", book);
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

