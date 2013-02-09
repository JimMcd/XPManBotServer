namespace PokerEngine
{
    public class Hand
    {
        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            blind.ReceiveCard(deck.Next());
            button.ReceiveCard(deck.Next());

            blind.PostBlind();

            var buttonAction = button.GetAction();
            blind.OpponentsAction(buttonAction);
            var blindAction = blind.GetAction();
            button.OpponentsAction(blindAction);

            if (blindAction != "FOLD")
                blind.ReceiveChips(1);
        }
    }
}