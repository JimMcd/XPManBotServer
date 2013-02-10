using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.HeadsUp
{
    public class Fixture
    {
        public string BotOneName { get; private set; }
        public string BotTwoName { get; private set; }

        public Fixture(string botOneName, string botTwoName)
        {
            BotOneName = botOneName;
            BotTwoName = botTwoName;
        }
    }
}
