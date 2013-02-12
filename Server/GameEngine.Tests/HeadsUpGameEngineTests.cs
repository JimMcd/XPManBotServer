﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.HeadsUp;
using NUnit.Framework;

namespace GameEngine.Tests
{
    [TestFixture]
    public class HeadsUpGameEngineTests : ICreateFixtures, ICreateBots, ICreateHeadsUpGames
    {
        private bool _getFixturesCalled;
        private int _botsCreated;
        private FakeGame _game;

        [Test]
        public void gets_fixtures()
        {
            var engine = new HeadsUpGameEngine(this, this, this);
            engine.PlayAll();
            Assert.True(_getFixturesCalled);
        }

        [Test]
        public void creates_bots()
        {
            var engine = new HeadsUpGameEngine(this, this, this);
            engine.PlayAll();
            Assert.That(_botsCreated, Is.EqualTo(2));
        }

        [Test]
        public void plays_game()
        {
            var engine = new HeadsUpGameEngine(this, this, this);
            engine.PlayAll();
            Assert.True(_game.GamePlayed);
        }


        public List<Fixture> GetFixtures()
        {
            _getFixturesCalled = true;
            return new List<Fixture> { new Fixture("bot1", "bot2" )};
        }

        public IAmABot Create(string botName)
        {
            _botsCreated++;
            return new FakeBot();
        }

        public IAmAHeadsUpGame Create(IAmABot playerOne, IAmABot playerTwo)
        {
            _game = new FakeGame();
            return _game;
        }
    }

    public class FakeGame : IAmAHeadsUpGame
    {
        public FakeGame()
        {
            GamePlayed = false;
        }

        public bool GamePlayed
        {
            get;
            private set;
        }

        public void Play()
        {
            GamePlayed = true;
        }
    }

    public class FakeBot : IAmABot
    {
        public void SendMessage(string message)
        {
            
        }

        public string GetMessage()
        {
            return "";
        }

        public void SendGameOver()
        {
        }
    }
}