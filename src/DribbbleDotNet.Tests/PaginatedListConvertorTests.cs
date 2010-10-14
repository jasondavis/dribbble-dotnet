namespace DribbbleDotNet.Tests
{
    using Convertors;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class PaginatedListConvertorTests
    {
        [Test]
        public void CanRead_Empty_Items()
        {
            // Arrange
            var expected = new PaginatedList<Player> { Page = 1, Pages = 100, Total = 1500, PerPage = 15 };
            var jsonString = JsonConvert.SerializeObject(expected);

            var convertor = new PaginatedListConvertor<Player>("players");

            // Act
            var players = JsonConvert.DeserializeObject<PaginatedList<Player>>(jsonString, convertor);

            // Assert
            Assert.AreEqual(expected.Page, players.Page);
            Assert.AreEqual(expected.Pages, players.Pages);
            Assert.AreEqual(expected.Total, players.Total);
            Assert.AreEqual(expected.PerPage, players.PerPage);
        }

        [Test]
        public void CanRead_With_Items()
        {
            // Arrange
            var convertor = new PaginatedListConvertor<Player>("players");
            var json = "{\"Page\":1,\"Pages\":100,\"per_page\":15,\"Total\":1500,\"players\":[{\"Id\":0,\"Name\":\"Jake\",\"Username\":null,\"Location\":null,\"twitter_screen_name\":null,\"created_at\":null,\"drafted_by_player_id\":null,\"Url\":null,\"avatar_url\":null,\"website_url\":null,\"shots_count\":0,\"followers_count\":0,\"following_count\":0,\"likes_count\":0,\"likes_received_count\":0,\"rebounds_count\":0,\"rebounds_received_count\":0,\"draftees_count\":0,\"comments_count\":0,\"comments_received_count\":0}]}";

            // Act
            var players = JsonConvert.DeserializeObject<PaginatedList<Player>>(json, convertor);

            // Assert
            Assert.AreEqual(1, players.Page);
            Assert.AreEqual(100, players.Pages);
            Assert.AreEqual(1500, players.Total);
            Assert.AreEqual(15, players.PerPage);
            Assert.AreEqual(1, players.Items.Count);
        }
    }
}