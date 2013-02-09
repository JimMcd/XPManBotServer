namespace PokerEngine.Tests.Fakes
{
    public class FakePlayer : IPlayOneCardPoker
    {
        public void ReceiveCard(string card)
        {
        }

        public void PostBlind()
        {
        }

        public void SendStartingChips(int chips)
        {
        }

        public string GetAction()
        {
            return string.Empty;
        }

        public void OpponentsAction(string action)
        {
        }
    }
}