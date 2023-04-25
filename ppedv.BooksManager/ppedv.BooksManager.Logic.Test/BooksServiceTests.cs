using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Logic.Test
{
    public class BooksServiceTests
    {
        [Fact]
        public void Ctor_with_null_should_throw()
        {
            Assert.Throws<ArgumentNullException>("readRepository", () => new BooksService(null!));
        }


    }


    public class TestRepo : IReadRepository
    {
        public IEnumerable<Book> GetAll()
        {
            yield return new Book() { Id = 1, Title = "Art of Testing", PageCount = 743, Price = 583.37m, ReleaseDate = new DateTime(2023, 04, 24) };
            yield return new Book() { Id = 2, Title = "The Clean Coder: A Code of Conduct for Professional Programmers", PageCount = 256, Price = 29.99m, ReleaseDate = new DateTime(2011, 05, 23) };
            yield return new Book() { Id = 3, Title = "Code Complete: A Practical Handbook of Software Construction, Second Edition", PageCount = 960, Price = 34.99m, ReleaseDate = new DateTime(2004, 06, 09) };
            yield return new Book() { Id = 4, Title = "Clean Architecture: A Craftsman's Guide to Software Structure and Design", PageCount = 432, Price = 35.96m, ReleaseDate = new DateTime(2017, 09, 20) };
            yield return new Book() { Id = 5, Title = "The Pragmatic Programmer: Your Journey to Mastery, 20th Anniversary Edition", PageCount = 352, Price = 44.99m, ReleaseDate = new DateTime(2019, 10, 11) };
            yield return new Book() { Id = 6, Title = "Cracking the Coding Interview: 189 Programming Questions and Solutions, 6th Edition", PageCount = 706, Price = 39.89m, ReleaseDate = new DateTime(2015, 07, 01) };
        }
    }
}