namespace GameEngine.HeadsUp
{
    public interface IAmABot
    {
        void SendMessage(string message);
        string GetMessage();
        void SendGameOver();
    }
}