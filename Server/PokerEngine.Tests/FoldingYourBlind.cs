using NUnit.Framework;
using PokerEngine.Tests.Fakes;

namespace PokerEngine.Tests
{
    [TestFixture]
    public class ButtonFoldsToReraise
    {
        [Test]
        public void hero_takes_5_chips()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();


            villain.Will("BET", "FOLD");
            hero.Will("BET");

            var hand = new Hand(hero, villain, new FakeDeck("A", "2"));

            Assert.That(hero.ReceivedChipAmount, Is.EqualTo(5));
        }        
        
        [Test]
        public void villain_loses_2_chips()
        {
            var hero = new FakePlayer();
            var villain = new FakePlayer();


            villain.Will("BET", "FOLD");
            hero.Will("BET");

            var hand = new Hand(hero, villain, new FakeDeck("A", "2"));

            Assert.That(villain.TotalLostChips, Is.EqualTo(2));
        }
    }



    [TestFixture]
    public class FoldingYourBlind : IManagePlayersStack
    {

        private bool _chipsReceived = false;
        private bool _actionSent = false;
        private int _chipsLost;

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

        [Test]
        public void lose_one_chip()
        {
            var hand = new Hand(this, new AlwaysRaises(), new FakeDeck("A", "2"));

            Assert.That(_chipsLost, Is.EqualTo(1));
        }

        public int Stack
        {
            get { throw new System.NotImplementedException(); }
        }

        public void DeductChips(int chipAmount)
        {
            _chipsLost = chipAmount;
        }

        public string Name
        {
            get { throw new System.NotImplementedException(); }
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

        public void SendButton()
        {
            
        }
    }
}
