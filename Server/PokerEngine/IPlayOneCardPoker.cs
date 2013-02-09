namespace PokerEngine
{
    public interface IPlayOneCardPoker
    {
        void ReceiveCard(string card);
        void PostBlind();
        void SendStartingChips(int chips);
    }
}