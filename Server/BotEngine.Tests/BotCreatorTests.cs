using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BotEngine.Tests
{
    [TestFixture]
    public class BotCreatorTests
    {
        [Test]
        public void create_returns_bot()
        {
            var result = new BotCreator().Create("test");
            Assert.That(result, Is.TypeOf<Bot>());
        }
    }
}
