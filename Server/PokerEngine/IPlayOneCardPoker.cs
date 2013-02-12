namespace PokerEngine
{
    public interface IManagePlayersStack : IPlayOneCardPoker
    {
        int Stack { get; }
        void DeductChips(int chipAmount);
    }

    public interface IPlayOneCardPoker
    {
        string Name { get; }
        void ReceiveCard(string card);
        void PostBlind();
        void SendStartingChips(int chips);
        string GetAction();
        void OpponentsAction(string action);
        void ReceiveChips(int amount);
    }
}