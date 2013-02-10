using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public interface ICreateBots
    {
        Bot Create(string botName);
    }
}
