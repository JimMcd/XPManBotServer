namespace PokerEngine
{
    public class Hand
    {
        public Hand(IPlayOneCardPoker p1, IPlayOneCardPoker p2, IRandomiseCards deck)
        {
            p1.ReceiveCard(deck.Next());
            p2.ReceiveCard(deck.Next());

            p1.PostBlind();
        }
    }
}