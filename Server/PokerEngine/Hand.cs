namespace PokerEngine
{
    public class Hand
    {
        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            DealCards(blind, button, deck);

            blind.PostBlind();
            int pot = 1;

            var buttonAction = button.GetAction();
            blind.OpponentsAction(buttonAction);

            if (buttonAction == "FOLD")
            {
                blind.ReceiveChips(pot);
                return;
            }

            pot+=1;

            var blindAction = blind.GetAction();
            button.OpponentsAction(blindAction);

            if (blindAction == "CALL")
            {
                blind.ReceiveChips(pot);
                return;
            }

            pot+=1;

            if (buttonAction == "CALL")
                blind.ReceiveChips(pot);
        }

        private static void DealCards(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            blind.ReceiveCard(deck.Next());
            button.ReceiveCard(deck.Next());
        }
    }
}