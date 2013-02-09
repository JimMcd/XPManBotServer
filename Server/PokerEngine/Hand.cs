namespace PokerEngine
{
    public class Hand
    {
        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            blind.ReceiveCard(deck.Next());
            button.ReceiveCard(deck.Next());

            blind.PostBlind();

            blind.OpponentsAction(button.GetAction());
        }
    }
}