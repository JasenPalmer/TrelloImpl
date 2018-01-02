using Xunit;

namespace BasicTrelloImplementation.Tests
{
    public class TrelloTests
    {
        [Fact]
        public async void LoadBoardsNoToken()
        {
            Trello.Token = "";
            await Trello.LoadBoards();
            Assert.Empty(Trello.Boards);
        }

        [Fact]
        public async void LoadBoardsWithToken()
        {
            Trello.Token = "6142dd5f78a85df22f669c0251e68b24e049c654ca773e5e42558d37b3bcc0ee";
            await Trello.LoadBoards();
            Assert.NotEmpty(Trello.Boards);
        }

        [Fact]
        public async void LoadCardsNoId()
        {
            await Trello.LoadCards(null);
            Assert.Empty(Trello.Cards);
        }

        [Fact]
        public async void LoadCardsValid()
        {
            Trello.Token = "6142dd5f78a85df22f669c0251e68b24e049c654ca773e5e42558d37b3bcc0ee";
            await Trello.LoadCards("5a3897bdff184ac756503ec9");
            Assert.NotEmpty(Trello.Cards);
        }

        [Fact]
        public async void AddCommentNullComment()
        {
            await Trello.AddComment("5a3897ca92fdafbe29fc6877", null);
            Assert.False(Trello.CommentAdded);
        }

        [Fact]
        public async void AddCommentNoId()
        {
            await Trello.AddComment("", "TestComment");
            Assert.False(Trello.CommentAdded);
        }

        [Fact]
        public async void AddCommentValid()
        {
            await Trello.AddComment("5a3897ca92fdafbe29fc6877", "TestComment");
            Assert.True(Trello.CommentAdded);
        }

    }
}
