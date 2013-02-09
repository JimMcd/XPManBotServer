using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class StartingAHand : IPlayOneCardPoker
    {
        private string _dealtCard;
        private bool _postedBlind;

        [SetUp]
        public void UpSet()
        {
            _dealtCard = null;
            _postedBlind = false;
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

        [Test]
        public void prompts_first_player_to_post_blind()
        {
            var hand = new Hand(this, new FakePlayer(), new FakeDeck("A", "2"));

            Assert.That(_postedBlind, Is.EqualTo(true));
        }

        [Test]
        public void second_player_does_not_have_to_post_blind()
        {
            var hand = new Hand(new FakePlayer(), this, new FakeDeck("A", "2"));

            Assert.That(_postedBlind, Is.EqualTo(false));
        }

        public void ReceiveCard(string card)
        {
            _dealtCard = card;
        }

        public void PostBlind()
        {
            _postedBlind = true;
        }

        public void SendStartingChips(int chips)
        {
        }
    }
}
