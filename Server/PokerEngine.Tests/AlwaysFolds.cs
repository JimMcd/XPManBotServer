namespace PokerEngine.Tests
{
    public class AlwaysFolds : IManagePlayersStack
    {
        public int Stack
        {
            get { throw new System.NotImplementedException(); }
        }

        public void DeductChips(int chipAmount)
        {
            throw new System.NotImplementedException();
        }

        public string Name
        {
            get { return "AlwaysFolds"; }
        }

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
            return "FOLD";
        }

        public void OpponentsAction(string action)
        {
        }

        public void ReceiveChips(int amount)
        {
            
        }
    }
}