using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Server.Tests
{
    [TestFixture]
    public class GameCreatorTests : ICreateBots
    {
        private int _botsCreated;

        [Test]
        public void game_creator_creates_two_bots()
        {
            var gameCreator = new GameCreator(this);
            gameCreator.CreateGame("bot1", "bot2");
            Assert.That(_botsCreated, Is.EqualTo(2));
        }

        public string Create(string botName)
        {
            _botsCreated++;
            return "";
        }
    }

    
}
