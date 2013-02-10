using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Tests.Fakes
{
    public class FakeBotFinder : IFindBots
    {
        private readonly string[] _bots;

        public FakeBotFinder(string [] bots)
        {
            _bots = bots;
        }

        public IList<string> Find()
        {
            return _bots;
        }
    }
}
