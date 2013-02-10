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
            _p1 = p1;
            _p2 = p2;
            _handFactory = handFactory;
            p1.SendStartingChips(startingChipCount);
            p2.SendStartingChips(startingChipCount);
        }

        public void PlayHand()
        {
            _handFactory.CreateHand(_p1, _p2);
        }

        public void ReportWinner(object playerGetsAllIn)
        {
        }
    }
}