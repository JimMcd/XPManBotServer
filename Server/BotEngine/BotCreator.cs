using GameEngine.HeadsUp;

namespace BotEngine
{
    public class BotCreator : ICreateBots
    {
        public IAmABot Create(string botName)
        {
            return new Bot(botName);
        }
    }
}
