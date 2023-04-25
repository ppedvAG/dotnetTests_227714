using FluentAssertions;
using Moq;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Logic.Test
{
    public class BooksServiceTests
    {
        [Fact]
        public void Ctor_with_null_should_throw()
        {
            var act = () => new BooksService(null!);

            act.Should().Throw<ArgumentNullException>().WithParameterName("readRepository");
            //Assert.Throws<ArgumentNullException>("readRepository", () => new BooksService(null!));
        }

        [Fact]
        public void GetBooksOfYearOrderByPrice_should_filter_years_results_5_of_6_Books()
        {
            var testRepo = new TestRepo();
            var bs = new BooksService(testRepo);

            var result = bs.GetBooksOfYearOrderByPrice(2023);

            result.Should().HaveCount(5).And.AllSatisfy(x => x.Id.Should().BeLessThan(6));
            //Assert.Equal(5, result.Count());
        }

        [Fact]
        public void GetBooksOfYearOrderByPrice_should_filter_years_results_2_of_3_Books_moq()
        {
            var b1 = new Book() { Id = 1, ReleaseDate = new DateTime(2023, 04, 24) };
            var b2 = new Book() { Id = 2, ReleaseDate = new DateTime(9999, 05, 23) };
            var b3 = new Book() { Id = 3, ReleaseDate = new DateTime(2023, 06, 09) };
            var mock = new Mock<IReadRepository>();
            mock.Setup(x => x.GetAll()).Returns(() => new[] { b1, b2, b3 });
            var bs = new BooksService(mock.Object);

            var result = bs.GetBooksOfYearOrderByPrice(2023);

            result.Should().HaveCount(2).And.AllSatisfy(x => x.Id.Should().BeOneOf(1, 3)).And.NotContain(b2);
        }

        [Fact]
        public void GetBooksOfYearOrderByPrice_should_order_results_by_price_descending()
        {
            var b1 = new Book() { Id = 1, Price = 60, ReleaseDate = new DateTime(2023, 04, 25) };
            var b2 = new Book() { Id = 2, Price = 40, ReleaseDate = new DateTime(2023, 04, 25) };
            var b3 = new Book() { Id = 3, Price = 120, ReleaseDate = new DateTime(2023, 04, 25) };
            var mock = new Mock<IReadRepository>();
            mock.Setup(x => x.GetAll()).Returns(() => new[] { b1, b2, b3 });

            var bs = new BooksService(mock.Object);

            var result = bs.GetBooksOfYearOrderByPrice(2023);

            result.Should().ContainInConsecutiveOrder(b3, b1, b2);
        }
    }

    public class TestRepo : IReadRepository
    {
        public IEnumerable<Book> GetAll()
        {
            yield return new Book() { Id = 1, Title = "Art of Testing", PageCount = 743, Price = 583.37m, ReleaseDate = new DateTime(2023, 04, 24) };
            yield return new Book() { Id = 2, Title = "The Clean Coder: A Code of Conduct for Professional Programmers", PageCount = 256, Price = 29.99m, ReleaseDate = new DateTime(2023, 05, 23) };
            yield return new Book() { Id = 3, Title = "Code Complete: A Practical Handbook of Software Construction, Second Edition", PageCount = 960, Price = 34.99m, ReleaseDate = new DateTime(2023, 06, 09) };
            yield return new Book() { Id = 4, Title = "Clean Architecture: A Craftsman's Guide to Software Structure and Design", PageCount = 432, Price = 35.96m, ReleaseDate = new DateTime(2023, 09, 20) };
            yield return new Book() { Id = 5, Title = "The Pragmatic Programmer: Your Journey to Mastery, 20th Anniversary Edition", PageCount = 352, Price = 44.99m, ReleaseDate = new DateTime(2023, 10, 11) };
            yield return new Book() { Id = 6, Title = "Cracking the Coding Interview: 189 Programming Questions and Solutions, 6th Edition", PageCount = 706, Price = 39.89m, ReleaseDate = new DateTime(2015, 07, 01) };
        }
    }
}