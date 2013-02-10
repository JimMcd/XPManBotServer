using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BotEngine
{
    public class BotFinder : IFindBots
    {
        private readonly string _locationToLook;

        public BotFinder(string locationToLook)
        {
            _locationToLook = locationToLook;
        }

        public List<string> Find()
        {
            var bots = Directory.GetDirectories(_locationToLook).ToList().ConvertAll(b => b.Replace(_locationToLook, ""));
            return bots;
        }
    }

    public interface IFindBots
    {
        List<string> Find();
    }
}
