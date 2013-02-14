using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class Deck : IRandomiseCards
    {
        List<string> _cards = new List<string>();
        private int _drawn;

        public Deck()
        {
            _cards.AddRange(new string[]{ "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"});
            _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
            _drawn = -1;
        }

        public string Next()
        {
            _drawn++;
            return _cards[_drawn];
        }
    }
}
