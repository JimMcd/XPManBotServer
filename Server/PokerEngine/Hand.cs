namespace PokerEngine
{
    public interface IHand
    {
    }

    public class Hand : IHand
    {
        private int _pot;
        private PlayerWithCard _actNext;
        private PlayerWithCard _actAfter;


        class PlayerWithCard
        {
            private readonly IManagePlayersStack _player;
            private readonly string _card;

            public IManagePlayersStack Player
            {
                get { return _player; }
            }

            public string Card
            {
                get { return _card; }
            }

            public PlayerWithCard(IManagePlayersStack player, string card)
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


        public Hand(IManagePlayersStack blind, IManagePlayersStack button, IRandomiseCards deck)
        {
            SetUpHand(blind, button, deck);
            ButtonFirstAction();
        }

        private void ButtonFirstAction()
        {
            var firstAction = _actNext.Act(_actAfter);

            switch (firstAction)
            {
                case "FOLD":
                    Wins(_actAfter);
                    break;
                case "CALL":
                    Bet(_actNext, 1);
                    GiveBlindOption();
                    break;
                case "BET":
                    Bet(_actNext, 2);
                    OpenUpAction();
                    break;
            }
        }

        private void GiveBlindOption()
        {
            SwitchToAct();
            var nextAction = _actNext.Act(_actAfter);

            switch (nextAction)
            {
                case "CALL":
                    ShowDown(_actAfter, _actNext);
                    break;
                case "BET":
                    Bet(_actNext, 1);
                    OpenUpAction();
                    break;
            }
        }

        private void OpenUpAction()
        {
            SwitchToAct();
            var nextAction = _actNext.Act(_actAfter);

            switch (nextAction)
            {
                case "FOLD":
                    Wins(_actAfter);
                    break;
                case "CALL":
                    Bet(_actNext, 1);
                    ShowDown(_actAfter, _actNext);
                    break;
                case "BET":
                    Bet(_actNext, 2);
                    OpenUpAction();
                    break;
            }
        }

        private void SwitchToAct()
        {
            var temp = _actNext;
            _actNext = _actAfter;
            _actAfter = temp;
        }

        private void SetUpHand(IManagePlayersStack blind, IManagePlayersStack button, IRandomiseCards deck)
        {
            _actAfter = new PlayerWithCard(blind, deck.Next());
            _actNext = new PlayerWithCard(button, deck.Next());

            PostBlinds(_actAfter);
        }

        private void PostBlinds(PlayerWithCard blind)
        {
            blind.Player.PostBlind();
            Bet(blind, 1);
        }

        private void Bet(PlayerWithCard bettor, int chipAmount)
        {
            bettor.Player.DeductChips(chipAmount);
            _pot += chipAmount;
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
        private const string Ranks = "23456789TJQKA";

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