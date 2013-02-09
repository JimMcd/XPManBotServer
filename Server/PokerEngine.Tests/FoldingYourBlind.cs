using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class FoldingYourBlind : IPlayOneCardPoker
    {
        private bool _chipsReceived = false;
        private bool _actionSent = false;

        [Test]
        public void get_prompted_for_action_when_opponent_raises()
        {
            var hand = new Hand(this, new AlwaysRaises(), new FakeDeck("A", "2"));

            Assert.That(_actionSent, Is.EqualTo(true));
        }

        [Test]
        public void dont_receive_chips()
        {
            var hand = new Hand(this, new AlwaysRaises(), new FakeDeck("A", "2"));

            Assert.That(_chipsReceived, Is.EqualTo(false));
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
            _actionSent = true;
            return "FOLD";
        }

        public void OpponentsAction(string action)
        {
        }

        public void ReceiveChips(int amount)
        {
            _chipsReceived = true;
        }
    }
}
