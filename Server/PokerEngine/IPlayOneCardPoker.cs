namespace PokerEngine
{
    public interface IPlayOneCardPoker
    {
        void ReceiveCard(string card);
        void PostBlind();
        void SendStartingChips(int chips);
        string GetAction();
        void OpponentsAction(string action);
    }
}