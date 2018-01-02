
using System.Net.Http;
using Xunit;

namespace BasicTrelloImplementation.Tests
{
    public class TrelloTests
    {

        public TrelloTests()
        {

        }

        [Fact]
        public void AuthoriseNoToken()
        {
            Trello.Token = "Test-Token";
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:51428/home/authorise?token=");
            Assert.Equal("Test-Token",Trello.Token);
        }

        [Fact]
        public void someOtherTest()
        {

        }


    }
}
