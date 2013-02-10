using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class FoldingYourButton
    {
        [Test]
        public void told_that_the_opponent_folded()
        {
            var hero = new FakePlayer();
            var hand = new Hand(hero, new AlwaysFolds(), new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedOpponentsAction, Is.EqualTo("FOLD"));
        }

        [Test]
        public void receives_one_chip_for_winning()
        {
            var hero = new FakePlayer();
            var hand = new Hand(hero, new AlwaysFolds(), new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedChipAmount, Is.EqualTo(1));
        }
    }
}