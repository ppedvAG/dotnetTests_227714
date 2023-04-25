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
    }
}