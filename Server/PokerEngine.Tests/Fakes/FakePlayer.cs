namespace PokerEngine.Tests.Fakes
{
    public class FakePlayer : IPlayOneCardPoker
    {
        public string ReceivedCard { get; set; }
        public string ReceivedOpponentsAction { get; set; }
        public int StartingChips { get; set; }
        public int ReceivedChipAmount { get; set; }
        public bool PostedBlind { get; set; }

        public void ReceiveCard(string card)
        {
            ReceivedCard = card;
        }

        public void PostBlind()
        {
            PostedBlind = true;
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