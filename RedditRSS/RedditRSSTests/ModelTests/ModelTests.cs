using NUnit.Framework;
using RedditRSS.Models;

namespace RedditRSSTests.ModelTests
{
    [TestFixture]
    public class ModelTests
    {
        // only things to test are correctness of equality overrides
        [Test]
        public void FeedEquality()
        {
            bool feedEquality = new Feed("1", "1", "1").Equals(new Feed("1", "1", "1"));
            Assert.That(feedEquality , Is.EqualTo(true));
        }

        [Test]
        public void FeedNoEquality()
        {
            bool feedEquality = new Feed("1", "1", "1").Equals(new Feed("2", "1", "1"));
            Assert.That(feedEquality, Is.EqualTo(false));
        }

        [Test]
        public void FeedItemEquality()
        {
            bool feedItemEquality = new FeedItem("1", "1", "1", "1", "1", "1").Equals(new FeedItem("1", "1", "1", "1", "1", "1"));
            Assert.That(feedItemEquality, Is.EqualTo(true));
        }

        [Test]
        public void FeedItemNoEquality()
        {
            bool feedItemEquality = new FeedItem("1", "1", "1", "1", "1", "1").Equals(new FeedItem("1", "1", "1", "1", "1", "2"));
            Assert.That(feedItemEquality, Is.EqualTo(false));
        }

    }
}
