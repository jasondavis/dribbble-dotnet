namespace DribbbleDotNet.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BaseTests
    {
        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Player { Id = 1 }, new Player { Id = 1 });
            Assert.AreEqual(new Shot { Id = 1 }, new Shot { Id = 1 });
            Assert.AreEqual(new Comment { Id = 1 }, new Comment { Id = 1 });

            Assert.AreNotEqual(new Player { Id = 1 }, new Player { Id = 2 });
            Assert.AreNotEqual(new Shot { Id = 1 }, new Shot { Id = 2 });
            Assert.AreNotEqual(new Comment { Id = 1 }, new Comment { Id = 2 });
        }
    }
}