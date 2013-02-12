using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.HeadsUp;

namespace Server
{
    public class Scoreboard : ITrackScores
    {
        private Dictionary<string, int> _scores;

        public Scoreboard()
        {
            _scores = new Dictionary<string, int>();
        }

        public void ReportWinner(string winnerName)
        {
            if (_scores.ContainsKey(winnerName))
                _scores[winnerName]++;
            else
                _scores.Add(winnerName, 1);
        }

        public void PrintScores()
        {
            foreach (var score in _scores)
            {
                Console.WriteLine(score.Key + ": " + score.Value + "wins");
            }
        }
    }
}
