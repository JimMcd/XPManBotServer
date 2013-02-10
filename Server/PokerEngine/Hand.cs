namespace PokerEngine
{
    public class Hand
    {
        private int _pot;
        private readonly PlayerWithCard _playerBlind, _playerButton;


        class PlayerWithCard
        {
            private readonly IPlayOneCardPoker _player;
            private readonly string _card;

            public IPlayOneCardPoker Player
            {
                get { return _player; }
            }

            public string Card
            {
                get { return _card; }
            }

            public PlayerWithCard(IPlayOneCardPoker player, string card)
            {
                _player = player;
                _card = card;
                player.ReceiveCard(card);
            }
        }


        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            _playerBlind = new PlayerWithCard(blind, deck.Next());
            _playerButton = new PlayerWithCard(button, deck.Next());

            PostBlinds();

            var buttonAction = _playerButton.Player.GetAction();
            _playerBlind.Player.OpponentsAction(buttonAction);

            if (buttonAction == "FOLD")
            {
                Wins(_playerBlind);
            }
            else
            {
                _pot += 1;

                var blindAction = _playerBlind.Player.GetAction();
                _playerButton.Player.OpponentsAction(blindAction);

                if (blindAction == "CALL")
                {
                    ShowDown();
                }
                else
                {
                    _pot += 1;

                    if (buttonAction == "CALL")
                        ShowDown();           
                }
            }
        }

        private void PostBlinds()
        {
            _playerBlind.Player.PostBlind();
            _pot = 1;
        }

        private void Wins(PlayerWithCard winner)
        {
            winner.Player.ReceiveChips(_pot);
        }

        private void ButtonWins()
        {
            _playerButton.Player.ReceiveChips(_pot);
        }

        private void ShowDown()
        {
            if (Ranks.IndexOf(_playerBlind.Card) > Ranks.IndexOf(_playerButton.Card))
                Wins(_playerBlind);
            else
                ButtonWins();
        }

        private const string Ranks = "2A";

    }

    internal interface IPlayerAction
    {
        void Do();
    }
}