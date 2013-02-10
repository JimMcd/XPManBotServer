using NUnit.Framework;
using Server.Tests.Fakes;

namespace Server.Tests
{
    [TestFixture]
    public class ServerTests : ICreateGames
    {
        private int _gamesCreated;

        [SetUp]
        public void Setup()
        {
            _gamesCreated = 0;
        }

        [Test]
        public void creates_one_game_with_two_bots()
        {
            var server = new BotServer(this, new FakeBotFinder(new [] { "bot1", "bot2" }));
            Assert.That(_gamesCreated, Is.EqualTo(1));
        }

        [Test]
        public void creates_three_games_with_three_bots()
        {
            var server = new BotServer(this, new FakeBotFinder(new[] { "bot1", "bot2", "bot3" }));
            Assert.That(_gamesCreated, Is.EqualTo(3));
        }

        public void Create(string bot1, string bot2)
        {
            _gamesCreated++;
        }
    }
}
