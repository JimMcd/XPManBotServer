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
            var p1 = new BotMessagenger(playerOne);
            var p2 = new BotMessagenger(playerTwo);

            p1.OpponentName(playerTwo.Name);
            p2.OpponentName(playerOne.Name);

            return new OneCardPokerGame(p1, p2, 10, new HandCreator());
        }
    }
}
