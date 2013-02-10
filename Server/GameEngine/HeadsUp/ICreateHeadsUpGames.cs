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
        void GetMessage(string message);
        string GetMessage();
    }

    public interface ICreateHeadsUpGames
    {
        IAmAHeadsUpGame Create(IAmABot playerOne, IAmABot playerTwo);
    }
}
