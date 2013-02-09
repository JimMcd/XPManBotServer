namespace PokerEngine
{
    public class OneCardPokerGame
    {
        public OneCardPokerGame(IPlayOneCardPoker p1, IPlayOneCardPoker p2, int startingChipCount)
        {
            p1.SendStartingChips(startingChipCount);
            p2.SendStartingChips(startingChipCount);
        }
    }
}