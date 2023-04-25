using FluentAssertions;

namespace ppedv.BooksManager.Data.GoogleApi.Tests
{
    public class BooksReadRepositoryTests
    {
        [Fact]
        [Trait("", "Integrationtest")]
        public void Can_GetAll_SoftwaretestsBooks()
        {
            BooksReadRepository repo = new BooksReadRepository();

            var result = repo.GetAll();

            result.Should().HaveCount(10);
        }


        [Fact]
        public void ToBook_ReturnsValidBook()
        {
            // Arrange
            var repository = new BooksReadRepository();
            var booksItem = new Item()
            {
                volumeInfo = new Volumeinfo()
                {
                    title = "Test Book",
                    pageCount = 100,
                    description = "A test book.",
                    publishedDate = "2022-01-01",
                    authors = new[] { "Test Author" }
                },
                saleInfo = new Saleinfo()
                {
                    listPrice = new Listprice()
                    {
                        amount = 10.99f,
                        currencyCode = "USD"
                    }
                }
            };

            // Act
            var book = repository.ToBook(booksItem);

            // Assert
            book.Id.Should().Be(1);
            book.Title.Should().Be("Test Book");
            book.PageCount.Should().Be(100);
            book.Price.Should().Be(10.99m);
            book.Description.Should().Be("A test book.");
            book.ReleaseDate.Should().Be(new DateTime(2022, 01, 01));
            book.Authors.Should().Contain("Test Author");
        }

        [Fact]
        public void ToBook_ReturnsValidBookWithEmptyValues()
        {
            // Arrange
            var repository = new BooksReadRepository();
            var booksItem = new Item()
            {
                volumeInfo = new Volumeinfo(),
                saleInfo = new Saleinfo()
            };

            // Act
            var book = repository.ToBook(booksItem);

            // Assert
            book.Id.Should().Be(1);
            book.Title.Should().Be(string.Empty);
            book.PageCount.Should().Be(0);
            book.Price.Should().Be(0);
            book.Description.Should().Be(string.Empty);
            book.ReleaseDate.Should().Be(DateTime.MinValue);
            book.Authors.Should().BeEmpty();
        }
    }
}