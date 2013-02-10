namespace PokerEngine
{
    public interface IPlayOneCardPoker
    {
        int Stack { get; }
        void DeductChips(int chipAmount);
        void ReceiveCard(string card);
        void PostBlind();
        void SendStartingChips(int chips);
        string GetAction();
        void OpponentsAction(string action);
        void ReceiveChips(int amount);
    }
}