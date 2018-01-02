using System.Net.Http;
using Xunit;

namespace BasicTrelloImplementation.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void AuthoriseNoToken()
        {
            Trello.Token = "Test-Token";
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/home/authorise?token=");
            Assert.Equal("Test-Token", Trello.Token);
        }
    }
}
