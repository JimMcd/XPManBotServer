namespace PokerEngine.Tests.Fakes
{
    public class FakePlayer : IPlayOneCardPoker
    {
        private string ReceivedCard { get; set; }
        private string ReceivedOpponentsAction { get; set; }
        private int StartingChips { get; set; }
        private int ReceivedChipAmount { get; set; }

        public void ReceiveCard(string card)
        {
            ReceivedCard = card;
        }

        public void PostBlind()
        {
        }

        public void SendStartingChips(int chips)
        {
            StartingChips = chips;
        }

        public string GetAction()
        {
            return string.Empty;
        }

        public void OpponentsAction(string action)
        {
            ReceivedOpponentsAction = action;
        }

        public void ReceiveChips(int amount)
        {
            ReceivedChipAmount = amount;
        }
    }
}