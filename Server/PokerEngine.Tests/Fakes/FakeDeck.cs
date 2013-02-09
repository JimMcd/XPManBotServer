using System.Collections.Generic;

namespace PokerEngine.Tests.Fakes
{
    public class FakeDeck : IRandomiseCards
    {
        private List<string> _cards;
        private int _drawn = 0;

        public FakeDeck(params string[] cards)
        {
            _cards = new List<string>(cards);
        }

        public string Next()
        {
            _drawn++;
            return _cards[_drawn - 1];
        }
    }
}