using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class FoldingTheHand : IPlayOneCardPoker
    {
        private string _opponentsAction;

        [Test]
        public void can_fold_the_hand()
        {
            var hand = new Hand(this, new AlwaysFolds(), new FakeDeck("A", "2"));

            Assert.That(_opponentsAction, Is.EqualTo("FOLD"));
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
    }
}