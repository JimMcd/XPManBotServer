using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.HeadsUp;

namespace PokerEngine
{
    public class HeadsUpGameCreator : ICreateHeadsUpGames
    {
        public IAmAHeadsUpGame Create(IAmABot playerOne, IAmABot playerTwo)
        {
            return new OneCardPokerGame(new BotMessagenger(playerOne), new BotMessagenger(playerTwo), 10, new HandCreator());
        }
    }
}
