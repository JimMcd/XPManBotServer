namespace PokerEngine
{
    public class Hand
    {
        private int _pot;
        private PlayerWithCard _playerBlind, _playerButton;
        private PlayerWithCard _actNext;
        private PlayerWithCard _actAfter;


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

            public string Act(PlayerWithCard opponent)
            {
                var action = _player.GetAction();
                opponent.Player.OpponentsAction(action);
                return action;
            }
        }


        public Hand(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            DealCards(blind, button, deck);

            PostBlinds(_playerBlind);

            _actNext = _playerButton;
            _actAfter = _playerBlind;

            var nextAction = _actNext.Act(_actAfter);

            if (nextAction == "FOLD")
            {
                Wins(_actAfter);
            }
            else if (nextAction == "CALL")
            {
                SwitchToAct();
                nextAction = _actNext.Act(_actAfter);

                if (nextAction == "CALL")
                {
                    _pot += 1;
                    ShowDown(_actAfter, _actNext);
                }
                else if (nextAction == "BET")
                {
                    _pot += 2;
                    SwitchToAct();
                    nextAction = _actNext.Act(_actAfter);

                    if (nextAction == "CALL")
                    {
                        _pot += 1;
                        ShowDown(_actAfter, _actNext);
                    }
                    else if (nextAction == "FOLD")
                        Wins(_actAfter);
                    else if (nextAction == "BET")
                    {
                        _pot += 1;
                        SwitchToAct();
                        nextAction = _actNext.Act(_actAfter);

                        if (nextAction == "CALL")
                            ShowDown(_actAfter, _actNext);
                        else if (nextAction == "FOLD")
                            Wins(_actAfter);
                    }
                }
            }
            else if (nextAction == "BET")
            {
                SwitchToAct();
                nextAction = _actNext.Act(_actAfter);
            }
        }

        private void SwitchToAct()
        {
            var temp = _actNext;
            _actNext = _actAfter;
            _actAfter = temp;
        }

        private void DealCards(IPlayOneCardPoker blind, IPlayOneCardPoker button, IRandomiseCards deck)
        {
            _playerBlind = new PlayerWithCard(blind, deck.Next());
            _playerButton = new PlayerWithCard(button, deck.Next());
        }

        private void PostBlinds(PlayerWithCard blind)
        {
            blind.Player.PostBlind();
            _pot = 1;
        }

        private void Wins(PlayerWithCard winner)
        {
            winner.Player.ReceiveChips(_pot);
        }

        private void ShowDown(PlayerWithCard p1, PlayerWithCard p2)
        {
            if (Card.Rank(p1.Card) > Card.Rank(p2.Card))
                Wins(p1);
            else
                Wins(p2);
        }
    }

    public class Card
    {
        private const string Ranks = "2A";

        public static int Rank(string card)
        {
            return Ranks.IndexOf(card, System.StringComparison.CurrentCulture);
        }
    }

    internal interface IEndHand
    {
    }

    internal interface IPlayerAction
    {
        void Do();
    }
}