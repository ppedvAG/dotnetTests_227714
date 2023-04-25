using ppedv.BooksManager.Model;
using System.Text.Json;

namespace ppedv.BooksManager.Data.GoogleApi
{
    public class BooksReadRepository : IReadRepository
    {
        public string Url { get; set; } = "https://www.googleapis.com/books/v1/volumes?q=softwaretests";

        public IEnumerable<Book> GetAll()
        {
            var http = new HttpClient();
            var json = http.GetStringAsync(Url).Result;

            var books = JsonSerializer.Deserialize<BooksResult>(json);

            foreach (var book in books.items)
            {
                yield return ToBook(book);
            }
        }
        int Id = 0;

        public Book ToBook(Item booksItem)
        {
            return new Book()
            {
                Id = Id++,
                Title = booksItem.volumeInfo.title,
                PageCount = booksItem.volumeInfo.pageCount,
                //Price = (decimal)book.saleInfo?.listPrice?.amount,
                Description = booksItem.volumeInfo.description,
                //ReleaseDate = DateTime.Parse(book.volumeInfo.publishedDate),
                Authors = booksItem.volumeInfo.authors
            };
        }
    }
}
