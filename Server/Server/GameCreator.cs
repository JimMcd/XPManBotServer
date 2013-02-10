using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class GameCreator : ICreateGames
    {
        private readonly ICreateBots _botCreator;

        public GameCreator(ICreateBots botCreator)
        {
            _botCreator = botCreator;
        }

        public void CreateGame(string bot1, string bot2)
        {
            var firstBot = _botCreator.Create(bot1);
            var secondBot = _botCreator.Create(bot2);
        }
    }


}
