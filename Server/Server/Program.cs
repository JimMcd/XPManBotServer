using BotEngine;
using GameEngine;
using PokerEngine;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var botCreator = new BotCreator();
            var fixtureCreator = new RoundRobinFixtures(new BotFinder(@"c:\bots"));
            var gameCreator = new HeadsUpGameCreator();
            var gameEngine = new HeadsUpGameEngine(botCreator, fixtureCreator, gameCreator);
            gameEngine.PlayAll();
        }
    }
}