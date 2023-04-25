namespace ppedv.BooksManager.Model
{
    public interface IReadRepository
    {
        IEnumerable<Book> GetAll();
    }
}
