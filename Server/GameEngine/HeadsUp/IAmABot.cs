namespace GameEngine.HeadsUp
{
    public interface IAmABot
    {
        string Name { get; }
        void SendMessage(string message);
        string GetMessage();
        void SendGameOver();
    }
}