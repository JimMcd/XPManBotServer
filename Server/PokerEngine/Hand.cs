namespace PokerEngine
{
    public class Hand
    {
        private int _pot;
        private IPlayOneCardPoker _blind, _button;
        private string _blindCard, _buttonCard;

        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            _blind = blind;
            _button = button;
            _blindCard = deck.Next();
            _buttonCard = deck.Next();

            Deal();
            PostBlinds();

            var buttonAction = _button.GetAction();
            _blind.OpponentsAction(buttonAction);

            if (buttonAction == "FOLD")
            {
                BlindWins();
                return;
            }

            _pot+=1;

            var blindAction = _blind.GetAction();
            _button.OpponentsAction(blindAction);

            if (blindAction == "CALL")
            {
                ShowDown();
                return;
            }

            _pot+=1;

            if (buttonAction == "CALL")
                BlindWins();
        }

        private void PostBlinds()
        {
            _blind.PostBlind();
            _pot = 1;
        }

        private void Deal()
        {
            _blind.ReceiveCard(_blindCard);
            _button.ReceiveCard(_buttonCard);
        }

        private void BlindWins()
        {
            _blind.ReceiveChips(_pot);
        }

        private void ButtonWins()
        {
            _button.ReceiveChips(_pot);
        }

        private void ShowDown()
        {
            if (ranks.IndexOf(_blindCard) > ranks.IndexOf(_buttonCard))
                BlindWins();
            else
                ButtonWins();
        }

        private const string ranks = "2A";

    }
}