using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class RaisingBlindToButtonsCall
    {
        [Test]
        public void hero_gets_chips()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();
            villain.Will("CALL", "FOLD");
            hero.Will("BET");

            var hand = new Hand(hero, villain, new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedChipAmount, Is.EqualTo(3));
        }
    }
}