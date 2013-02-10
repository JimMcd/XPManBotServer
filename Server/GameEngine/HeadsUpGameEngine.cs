using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.HeadsUp;

namespace GameEngine
{
    public class HeadsUpGameEngine
    {
        private readonly ICreateFixtures _botCreator;
        private readonly ICreateHeadsUpGames _gameCreator;

        public HeadsUpGameEngine(ICreateFixtures botCreator, ICreateHeadsUpGames gameCreator)
        {
            _botCreator = botCreator;
            _gameCreator = gameCreator;
        }
    }
}
