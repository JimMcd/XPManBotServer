using System.Collections.Generic;

namespace PokerEngine.Tests.Fakes
{
    public class FakePlayer : IPlayOneCardPoker
    {
        private List<string> _actions = new List<string>();
        private int _actionIndex = 0;

        public string ReceivedCard { get; set; }
        public string ReceivedOpponentsAction { get; set; }
        public int StartingChips { get; set; }
        public int ReceivedChipAmount { get; set; }
        public bool PostedBlind { get; set; }

        public string PlayerName { get; private set; }

        public FakePlayer()
        {
            PlayerName = "Unknown";
        }

        public FakePlayer(string playerName)
        {
            PlayerName = playerName;
        }

        public int Stack
        {
            get { throw new System.NotImplementedException(); }
        }

        public void DeductChips(int chipAmount)
        {
            throw new System.NotImplementedException();
        }

        public void ReceiveCard(string card)
        {
            ReceivedCard = card;
        }

        public void PostBlind()
        {
            PostedBlind = true;
        }

        public void SendStartingChips(int chips)
        {
            StartingChips = chips;
        }

        public string GetAction()
        {
            _actionIndex++;
            int index = _actionIndex - 1;
            if (_actions.Count > index)
                return _actions[index];


            return string.Empty;
        }

        public void OpponentsAction(string action)
        {
            ReceivedOpponentsAction = action;
        }

        public void ReceiveChips(int amount)
        {
            ReceivedChipAmount = amount;
        }

        public void Will(params string [] actions)
        {
            _actions = new List<string>(actions);
        }
    }
}