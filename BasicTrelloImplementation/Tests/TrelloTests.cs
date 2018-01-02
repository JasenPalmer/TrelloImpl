using NUnit.Framework;
using System.Net.Http;

namespace BasicTrelloImplementation.Tests
{
    [TestFixture]
    public class TrelloTests
    {



        public TrelloTests()
        {

        }

        [Test]
        public void AuthoriseNoToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:51428/home/authorise?token=");

        }


    }
}
