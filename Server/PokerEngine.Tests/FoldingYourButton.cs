using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class FoldingYourButton : IPlayOneCardPoker
    {
        private string _opponentsAction;
        private int _chipsReceived;

        [Test]
        public void told_that_the_opponent_folded()
        {
            var hand = new Hand(this, new AlwaysFolds(), new FakeDeck("A", "2"));

            Assert.That(_opponentsAction, Is.EqualTo("FOLD"));
        }

        [Test]
        public void receives_one_chip_for_winning()
        {
            var hand = new Hand(this, new AlwaysFolds(), new FakeDeck("A", "2"));

            Assert.That(_chipsReceived, Is.EqualTo(1));
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

        public string GetAction()
        {
            return string.Empty;
        }

        public void OpponentsAction(string action)
        {
            _opponentsAction = action;
        }

        public void ReceiveChips(int amount)
        {
            _chipsReceived = amount;
        }
    }

    public class AlwaysFolds : IPlayOneCardPoker
    {
        public void ReceiveCard(string card)
        {
        }

        public void PostBlind()
        {
        }

        public void SendStartingChips(int chips)
        {
        }

        public string GetAction()
        {
            return "FOLD";
        }

        public void OpponentsAction(string action)
        {
        }

        public void ReceiveChips(int amount)
        {
            
        }
    }
}