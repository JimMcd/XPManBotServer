using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.HeadsUp
{
    public interface ICreateBots
    {
        IAmABot Create(string botName);
    }
}
