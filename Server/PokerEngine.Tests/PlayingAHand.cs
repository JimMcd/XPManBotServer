using System.Collections.Generic;
using NUnit.Framework;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class PlayingAHand : IPlayOneCardPoker
    {
        private string _dealtCard;

        [SetUp]
        public void UpSet()
        {
            _dealtCard = null;
        }

        [Test]
        public void deals_cards_to_a_player()
        {
            var hand = new Hand(this, new FakePlayer(), new FakeDeck("A", "2"));

            Assert.That(_dealtCard, Is.EqualTo("A"));
        }

        [Test]
        public void deals_second_card_to_second_player()
        {
            var hand = new Hand(new FakePlayer(), this, new FakeDeck("A", "2"));

            Assert.That(_dealtCard, Is.EqualTo("2"));
        }

        public void ReceiveCard(string card)
        {
            _dealtCard = card;
        }
    }

    public class FakeDeck : IRandomiseCards
    {
        private List<string> _cards;
        private int _drawn = 0;

        public FakeDeck(params string[] cards)
        {
            _cards = new List<string>(cards);
        }

        public string Next()
        {
            _drawn++;
            return _cards[_drawn - 1];
        }
    }

    public interface IRandomiseCards
    {
        string Next();
    }

    public class Hand
    {
        public Hand(IPlayOneCardPoker p1, IPlayOneCardPoker p2, IRandomiseCards deck)
        {
            p1.ReceiveCard(deck.Next());
            p2.ReceiveCard(deck.Next());
        }
    }

    public interface IPlayOneCardPoker
    {
        void ReceiveCard(string card);
    }

    public class FakePlayer : IPlayOneCardPoker
    {
        public void ReceiveCard(string card)
        {
        }
    }
}
