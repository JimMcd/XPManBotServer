using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public interface ICreateGames
    {
        void Create(string bot1, string bot2);
    }
}
