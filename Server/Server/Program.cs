using BotEngine;
using GameEngine;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var botCreator = new BotCreator();
            var fixtureCreator = new RoundRobinFixtures(new BotFinder(@"c:\bots"));

            var gameEngine = new HeadsUpGameEngine(botCreator, fixtureCreator, null);
        }
    }
}