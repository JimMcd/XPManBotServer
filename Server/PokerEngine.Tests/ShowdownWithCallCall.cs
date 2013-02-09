using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class ShowdownWithCallCall
    {
        [Test]
        public void hero_gets_chips_with_best_card()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();
            villain.Will("CALL");
            hero.Will("CALL");

            var hand = new Hand(hero, villain, new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedChipAmount, Is.EqualTo(2));
        }

        [Test]
        public void villain_gets_chips_with_best_card()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();
            villain.Will("CALL");
            hero.Will("CALL");

            var hand = new Hand(hero, villain, new FakeDeck("2", "A"));

            Assert.That(villain.ReceivedChipAmount, Is.EqualTo(2));
        }


    }
}