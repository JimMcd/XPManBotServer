using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Server.Tests
{
    [TestFixture]
    public class will_load_bot_from_name
    {
        [Test]
        public void loads_ruby_bot_and_gets_message_from_it()
        {
            var finder = new BotFinder();
            var botname = finder.Find()[0];

            var bot = new Bot(botname);

            var result = bot.GetMessage();

            Assert.That(result, Is.EqualTo("Hello Server"));
        }
    }

    public class Bot
    {
        public Bot(string botname)
        {
            
        }

        public string GetMessage()
        {
            return "";
        }
    }
}
