using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class StartingAGame : IPlayOneCardPoker
    {
        private int _startingChips;

        [SetUp]
        public void UpSet()
        {
            _startingChips = 0;
        }

        [Test]
        public void starts_a_game_and_sends_chip_stacks_to_player1()
        {
            var game = new OneCardPokerGame(this, new FakePlayer(), 10);

            Assert.That(_startingChips, Is.EqualTo(10));
        }

        [Test]
        public void starts_a_game_and_sends_chip_stacks_to_player2()
        {
            var game = new OneCardPokerGame(new FakePlayer(), this, 10);

            Assert.That(_startingChips, Is.EqualTo(10));
        }

        public void ReceiveCard(string card)
        {
        }

        public void PostBlind()
        {
        }

        public void SendStartingChips(int chips)
        {
            _startingChips = chips;
        }
    }


    [TestFixture]
    public class FoldingTheHand : IPlayOneCardPoker
    {
        [Test]
        public void can_fold_the_hand()
        {
            var hand = new Hand(new FakePlayer(), this, new FakeDeck("A", "2"));
        }

        public void ReceiveCard(string card)
        {
        }

        public void PostBlind()
        {
        }

        public void SendStartingChips(int chips)
        {
            
        }
    }
}