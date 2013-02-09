using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class StartingAHand
    {
        [Test]
        public void deals_cards_to_a_player()
        {
            var hero = new FakePlayer();
            var hand = new Hand(hero, new FakePlayer(), new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedCard, Is.EqualTo("A"));
        }

        [Test]
        public void deals_second_card_to_second_player()
        {
            var hero = new FakePlayer();
            var hand = new Hand(new FakePlayer(), hero, new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedCard, Is.EqualTo("2"));
        }

        [Test]
        public void prompts_first_player_to_post_blind()
        {
            var hero = new FakePlayer();
            var hand = new Hand(hero, new FakePlayer(), new FakeDeck("A", "2"));

            Assert.That(hero.PostedBlind, Is.EqualTo(true));
        }

        [Test]
        public void second_player_does_not_have_to_post_blind()
        {
            var hero = new FakePlayer();
            var hand = new Hand(new FakePlayer(), hero, new FakeDeck("A", "2"));

            Assert.That(hero.PostedBlind, Is.EqualTo(false));
        }
    }
}
