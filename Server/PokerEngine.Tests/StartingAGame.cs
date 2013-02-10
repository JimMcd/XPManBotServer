using System;
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


        public IHand CreateHand(IPlayOneCardPoker p1, IPlayOneCardPoker p2)
        {
            return new Hand(p1, p2, _deckBuilder());
        }
    }


    [TestFixture]
    public class PlayerGetsAllIn
    {
        [Test]
        public void something()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();


            hero.Will("BET", "BET", "BET", "BET");
            villain.Will("BET", "BET", "BET", "BET");

            var game = new OneCardPokerGame(hero, villain, 2, new FakeHandFactory(() => new FakeDeck("A", "2")));

            game.ReportWinner(this);
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
            var p1 = new FakePlayer();
            var p2 = new FakePlayer();
            var game = new OneCardPokerGame(p1, p2, 10, this);

            game.PlayHand();

            Assert.That(_handCreated, Is.True);
        }

        public IHand CreateHand(IPlayOneCardPoker p1, IPlayOneCardPoker p2)
        {
            _handCreated = true;
            return new Hand(p1, p2, new FakeDeck("A", "2"));
        }
    }

}