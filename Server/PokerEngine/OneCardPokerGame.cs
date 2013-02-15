using System;
using GameEngine.HeadsUp;

namespace PokerEngine
{
    public interface ICreateHands
    {
        IHand CreateHand(IManagePlayersStack p1, IManagePlayersStack p2);
    }

    public class OneCardPokerGame : IAmAHeadsUpGame
    {
        private readonly IManagePlayersStack _p1;
        private readonly IManagePlayersStack _p2;
        private readonly ICreateHands _handFactory;
        private string _winnerName;

        public OneCardPokerGame(IPlayOneCardPoker p1, IPlayOneCardPoker p2, int startingChipCount, ICreateHands handFactory)
        {
            _p1 = new StackCoordinator(p1);
            _p2 = new StackCoordinator(p2);
            _handFactory = handFactory;
            _p1.SendStartingChips(startingChipCount);
            _p2.SendStartingChips(startingChipCount);
        }

        public void Play()
        {
            bool swapButton = false;

            while (_p1.Stack > 0 && _p2.Stack > 0)
            {
                if (swapButton)
                {
                    var h = _handFactory.CreateHand(_p1, _p2);
                }
                else
                {
                   var h = _handFactory.CreateHand(_p2, _p1);
                }

                swapButton = !swapButton;
            }

            if (_p1.Stack > 0)
                _winnerName = _p1.Name;
            else
                _winnerName = _p2.Name;

            Console.WriteLine(_winnerName + " WINS!");
        }

        public void ReportWinner(ITrackScores scoreBoard)
        {
            scoreBoard.ReportWinner(_winnerName);
        }
    }

    public class StackCoordinator : IManagePlayersStack
    {
        private readonly IPlayOneCardPoker _inner;

        public StackCoordinator(IPlayOneCardPoker inner)
        {
            _inner = inner;
        }

        public int Stack { get; private set; }

        public void DeductChips(int chipAmount)
        {
            Stack -= chipAmount;
        }

        public string Name
        {
            get { return _inner.Name; }
        }

        public void ReceiveCard(string card)
        {
            _inner.ReceiveCard(card);
        }

        public void PostBlind()
        {
            _inner.PostBlind();
        }

        public void SendStartingChips(int chips)
        {
            Stack = chips;
            _inner.SendStartingChips(chips);
        }

        public string GetAction()
        {
            var action = _inner.GetAction();
            if (action == "BET" && Stack < 2)
                return "CALL";
            return action;
        }

        public void OpponentsAction(string action)
        {
            _inner.OpponentsAction(action);
        }

        public void ReceiveChips(int amount)
        {
            this.Stack += amount;
            _inner.ReceiveChips(amount);
        }

        public void SendButton()
        {
            _inner.SendButton();
        }
    }

    public class BotMessagenger : IPlayOneCardPoker
    {
        private readonly IAmABot _bot;

        public BotMessagenger(IAmABot bot)
        {
            Name = bot.Name;
            _bot = bot;
        }

        public string Name { get; private set; }

        public void ReceiveCard(string card)
        {
            _bot.SendMessage("CARD:" + card);
        }

        public void PostBlind()
        {
            _bot.SendMessage("BLIND");
        }

        public void SendStartingChips(int chips)
        {
            _bot.SendMessage("STARTING_CHIPS:" + chips);
        }

        public string GetAction()
        {
            return _bot.GetMessage();
        }

        public void OpponentsAction(string action)
        {
            _bot.SendMessage("OPPONENT:" + action);
        }

        public void ReceiveChips(int amount)
        {
            _bot.SendMessage("WON:" + amount);
        }

        public void SendButton()
        {
            _bot.SendMessage("BUTTON");
        }

        public void OpponentName(string name)
        {
            _bot.SendMessage("OPPONENT_NAME:" + name);
        }
    }
}