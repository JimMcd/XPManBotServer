using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Server
{
    public interface IFindBots
    {
        IList<string> Find();
    }

    public class BotFinder : IFindBots
    {
        public IList<string> Find()
        {
            const string botsDirectory = @"c:\bots";
            var bots = Directory.GetDirectories(botsDirectory).ToList().ConvertAll(b => b.Replace(botsDirectory, ""));
            return bots;
        }
    }
}