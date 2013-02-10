namespace Server
{
    public class BotCreator : ICreateBots
    {
        public Bot Create(string botName)
        {
            return new Bot(new ProcessBot(botName));
        }
    }
}
