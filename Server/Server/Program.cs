using System;
using System.Diagnostics;
using System.IO;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var botFinder = new BotFinder();
            var botServer = new BotServer(new GameCreator(new BotCreator()), botFinder);
        }
    }


    public class Bot
    {
        private readonly ProcessBot _processBot;

        public Bot(ProcessBot processBot)
        {
            _processBot = processBot;
        }
    }



    public class PokerConfiguration
    {
        
    }
}