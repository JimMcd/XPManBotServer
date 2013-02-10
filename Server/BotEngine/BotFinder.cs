using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BotEngine
{
    public class BotFinder
    {
        private readonly string _locationToLook;

        public BotFinder(string locationToLook)
        {
            _locationToLook = locationToLook;
        }

        public IList<string> Find()
        {
            var bots = Directory.GetDirectories(_locationToLook).ToList().ConvertAll(b => b.Replace(_locationToLook, ""));
            return bots;
        }
    }
}
