using GameEngine.HeadsUp;

namespace GameEngine
{
    public class HeadsUpGameEngine
    {
        private readonly ICreateBots _botCreator;
        private readonly ICreateFixtures _fixtureCreator;
        private readonly ICreateHeadsUpGames _gameCreator;

        public HeadsUpGameEngine(ICreateBots botCreator, ICreateFixtures fixtureCreator, ICreateHeadsUpGames gameCreator)
        {
            _botCreator = botCreator;
            _fixtureCreator = fixtureCreator;
            _gameCreator = gameCreator;
        }

        public void PlayAll(ITrackScores scoreBoard)
        {
            var fixtures = _fixtureCreator.GetFixtures();

            foreach (var fixture in fixtures)
            {
                var botOne = _botCreator.Create(fixture.BotOneName);
                var botTwo = _botCreator.Create(fixture.BotTwoName);
                var game = _gameCreator.Create(botOne,botTwo);
                game.Play();
                botOne.SendGameOver();
                botTwo.SendGameOver();
                game.ReportWinner(scoreBoard);
            }

        }
    }
}
