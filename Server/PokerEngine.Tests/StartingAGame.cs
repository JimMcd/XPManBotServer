using System;
using GameEngine.HeadsUp;
using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    public class FakeHandFactory : ICreateHands
    {
        private readonly Func<IRandomiseCards> _deckBuilder;

        public FakeHandFactory(Func<IRandomiseCards> deckBuilder)
        {
            _deckBuilder = deckBuilder;
        }


        public IHand CreateHand(IManagePlayersStack p1, IManagePlayersStack p2)
        {
            return new Hand(p1, p2, _deckBuilder());
        }
    }


    [TestFixture]
    public class GameEndsAfterTwoHands : ITrackScores
    {
        private string _winnerName;

        [Test]
        public void something()
        {
            var hero = new FakePlayer("Hero");
            var villain = new FakePlayer("Villain");

            villain.Will("CALL", "CALL", "CALL", "CALL");
            hero.Will("BET", "BET", "BET", "BET");

            var game = new OneCardPokerGame(hero, villain, 2, new FakeHandFactory(() => new FakeDeck("2", "A")));

            game.Play();

            game.ReportWinner(this);

            Assert.That(_winnerName, Is.EqualTo("Villain"));
        }

        public void ReportWinner(string winnerName)
        {
            _winnerName = winnerName;
        }
    }


    [TestFixture]
    public class PlayerGetsAllInFirstHand : ITrackScores
    {
        private string _winnerName;

        [Test]
        public void something()
        {
            var hero = new FakePlayer("Hero");
            var villain = new FakePlayer("Villain");

            hero.Will("BET", "BET", "BET", "BET");
            villain.Will("BET", "BET", "BET", "BET");

            var game = new OneCardPokerGame(hero, villain, 2, new FakeHandFactory(() => new FakeDeck("A", "2")));

            game.Play();

            game.ReportWinner(this);

            Assert.That(_winnerName, Is.EqualTo("Hero"));
        }

        public void ReportWinner(string winnerName)
        {
            _winnerName = winnerName;
        }
    }


    [TestFixture]
    public class StartingAGame : ICreateHands
    {
        private bool _handCreated;

        [Test]
        public void players_are_sent_the_starting_amount()
        {
            var p1 = new FakePlayer();
            var p2 = new FakePlayer();
            var game = new OneCardPokerGame(p1, p2, 10, this);

            Assert.That(p1.StartingChips, Is.EqualTo(10));
            Assert.That(p2.StartingChips, Is.EqualTo(10));
        }

        [Test]
        public void creates_a_hand_from_factory()
        {
            var p1 = new AlwaysRaises();
            var p2 = new AlwaysRaises();
            var game = new OneCardPokerGame(p1, p2, 10, this);

            game.Play();

            Assert.That(_handCreated, Is.True);
        }

        public IHand CreateHand(IManagePlayersStack p1, IManagePlayersStack p2)
        {
            _handCreated = true;
            return new Hand(p1, p2, new FakeDeck("A", "2"));
        }
    }

}