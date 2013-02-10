using System.Collections.Generic;
using System.Linq;
using GameEngine.HeadsUp;

namespace BotEngine
{
    public class RoundRobinFixtures : ICreateFixtures
    {
        private readonly List<Fixture> _fixtures; 

        public RoundRobinFixtures(BotFinder botFinder)
        {
            _fixtures = new List<Fixture>();
            var bots = botFinder.Find().ToList();

            while (bots.Count > 1)
            {
                var bot1 = bots.First();
                bots.Remove(bot1);
                bots.ForEach(bot2 => _fixtures.Add(new Fixture(bot1, bot2)));
            }
        }

        public List<Fixture> GetFixtures()
        {
            return _fixtures;
        }
    }
}
