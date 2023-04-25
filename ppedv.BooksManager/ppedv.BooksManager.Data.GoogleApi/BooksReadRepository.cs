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
        int _id = 0;

        public Book ToBook(Item booksItem)
        {
            return new Book()
            {
                Id = ++_id,
                Title = booksItem.volumeInfo.title ?? string.Empty,
                PageCount = booksItem.volumeInfo.pageCount,
                Price = (decimal)(booksItem.saleInfo?.listPrice?.amount ?? 0),
                Description = booksItem.volumeInfo.description ?? string.Empty,
                ReleaseDate = DateTime.TryParse(booksItem.volumeInfo.publishedDate, out var releaseDate) ? releaseDate : DateTime.MinValue,
                Authors = booksItem.volumeInfo.authors != null ? new HashSet<string>(booksItem.volumeInfo.authors) : new HashSet<string>()
            };
        }
    }
}
