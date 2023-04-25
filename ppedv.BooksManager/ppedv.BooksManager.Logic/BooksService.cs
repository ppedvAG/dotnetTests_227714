using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Logic
{
    public class BooksService
    {
        public IReadRepository ReadRepository { get; }

        public BooksService(IReadRepository readRepository)
        {
            if (readRepository == null)
                throw new ArgumentNullException(nameof(readRepository));

            ReadRepository = readRepository;
        }

        public IEnumerable<Book> GetBooksOfYearOrderByPrice(int year)
        {
            return ReadRepository.GetAll()
                                 .Where(x => x.ReleaseDate.Year == year)
                                 .OrderByDescending(x => x.Price);
        }
    }
}