using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.HeadsUp
{
    public interface IAmAHeadsUpGame
    {
        void Play();
    }

    public interface IAmABot
    {
        void ReceiveMessage();
        string SendMessage();
    }

    public interface ICreateHeadsUpGames
    {
        IAmAHeadsUpGame Create(IAmABot playerOne, IAmABot playerTwo);
    }
}
