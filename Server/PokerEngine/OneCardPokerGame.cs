using GameEngine.HeadsUp;

namespace PokerEngine
{
    public interface ICreateHands
    {
        IHand CreateHand(IPlayOneCardPoker p1, IPlayOneCardPoker p2);
    }

    public class OneCardPokerGame
    {
        private readonly IPlayOneCardPoker _p1;
        private readonly IPlayOneCardPoker _p2;
        private readonly ICreateHands _handFactory;

        public OneCardPokerGame(IPlayOneCardPoker p1, IPlayOneCardPoker p2, int startingChipCount, ICreateHands handFactory)
        {
            _p1 = new CallIfNotEnoughChipsDecorator(p1);
            _p2 = new CallIfNotEnoughChipsDecorator(p2);
            _handFactory = handFactory;
            p1.SendStartingChips(startingChipCount);
            p2.SendStartingChips(startingChipCount);
        }

        public void PlayHand()
        {
            var hand = _handFactory.CreateHand(_p1, _p2);
        }

        public void ReportWinner(ITrackScores scoreBoard)
        {
            scoreBoard.ReportWinner("Hero");
        }
    }

    public class CallIfNotEnoughChipsDecorator :IPlayOneCardPoker
    {
        private readonly IPlayOneCardPoker _inner;

        public CallIfNotEnoughChipsDecorator(IPlayOneCardPoker inner )
        {
            _inner = inner;
        }

        public int Stack
        {
            get { return _inner.Stack; }
        }

        public void DeductChips(int chipAmount)
        {
            _inner.DeductChips(chipAmount);
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
            _inner.SendStartingChips(chips);
        }

        public string GetAction()
        {
            var action = _inner.GetAction();
            if (action == "BET" && _inner.Stack < 2)
                return "CALL";
            return action;
        }

        public void OpponentsAction(string action)
        {
            _inner.OpponentsAction(action);
        }

        public void ReceiveChips(int amount)
        {
            _inner.ReceiveChips(amount);
        }
    }
}