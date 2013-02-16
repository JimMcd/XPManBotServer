using System;
using BotEngine;
using GameEngine;
using PokerEngine;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var scoreBoard = new Scoreboard();
            while (true) {
                var botCreator = new BotCreator();
                var fixtureCreator = new RoundRobinFixtures(new BotFinder(@"c:\bots"));
                var gameCreator = new HeadsUpGameCreator();
                var gameEngine = new HeadsUpGameEngine(botCreator, fixtureCreator, gameCreator);
                
                gameEngine.PlayAll(scoreBoard);

                scoreBoard.PrintScores();
                Console.ReadLine();
            }
        }
    }
}