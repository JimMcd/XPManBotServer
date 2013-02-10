using System.Linq;

namespace Server.Tests
{
    public class BotServer
    {
        public BotServer(ICreateGames gameCreator, IFindBots botFinder)
        {
            var bots = botFinder.Find().ToList();

            while (bots.Count > 1)
            {
                var bot1 = bots.First();
                bots.Remove(bot1);
                bots.ForEach(bot2 => gameCreator.CreateGame(bot1, bot2));
            }
        }
    }
}