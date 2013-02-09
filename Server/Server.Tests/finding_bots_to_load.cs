using NUnit.Framework;

namespace Server.Tests
{
    [TestFixture]
    public class finding_bots_to_load
    {
        [Test]
        public void finds_bots_in_c_bots()
        {
            var foundBotsCount = new BotFinder().Find().Count;
            Assert.That(foundBotsCount, Is.EqualTo(1));
        }
    }
}
