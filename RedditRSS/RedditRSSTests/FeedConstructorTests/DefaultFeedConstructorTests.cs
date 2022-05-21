using NUnit.Framework;
using System.Xml.Linq;
using RedditRSS.Models;
using RedditRSS.Models.FeedConstruction;

namespace RedditRSSTests.FeedConstructorTests
{   
    [TestFixture]
    public class DefaultFeedConstructorTests
    {
        private IFeedConstructor fc;
        /*
         * requirements:
         * - only takes RSS feeds from www.reddit.com, XML is assumed to follow the reddit RSS structure.
         *   (example XML file is found in the root of the project RedditRSS_Example.xml)
         * - user manually types in the RSS feed URL, excpect any input.
         */

        [SetUp]
        public void SetUp()
        {
            fc = new DefaultFeedConstructor();
        }

        // RedditRSS.Models.FeedConstruction.DefaultFeedConstructor.ConstructFeed
        // not sure how to test without actually fetching the RSS feed every time a test is run.


        // RedditRSS.Models.FeedConstruction.DefaultFeedConstructor.ConstructFeedItem

        // A reddit post (an item in our feed) can be uniquely determined by its post ID
        // An author could post the exact same content twice, but it would still technically
        //  be considered two different posts 
        [Test]
        public void ConstructFeedItemSameID()
        {
            XElement rssEntryItem = new XElement("entry",
                new XElement("author", new XElement("name", ""), new XElement("uri", "")),
                new XElement("category", new XAttribute("term", ""), new XAttribute("label", "")),
                new XElement("content", new XAttribute("type", ""), ""),
                new XElement("id", "1"),
                new XElement("link", new XAttribute("href", "")),
                new XElement("updated", ""),
                new XElement("published", ""),
                new XElement("title", "")
);
            FeedItem feedItem = new FeedItem("", "", "", "", "", "1");

            bool feedItemEquality = fc.ConstructFeedItem(rssEntryItem).Equals(feedItem);

            Assert.That(feedItemEquality, Is.EqualTo(true));
        }

        [Test]
        public void ConstructFeedItemSameDifferentID()
        {
            XElement rssEntryItem = new XElement("entry",
                new XElement("author", new XElement("name", ""), new XElement("uri", "")),
                new XElement("category", new XAttribute("term", ""), new XAttribute("label", "")),
                new XElement("content", new XAttribute("type", ""), ""),
                new XElement("id", "1"),
                new XElement("link", new XAttribute("href", "")),
                new XElement("updated", ""),
                new XElement("published", ""),
                new XElement("title", "")
);
            FeedItem feedItem = new FeedItem("", "", "", "", "", "2");

            bool feedItemEquality = fc.ConstructFeedItem(rssEntryItem).Equals(feedItem);

            Assert.That(feedItemEquality, Is.EqualTo(false));
        }

        [Test]
        public void ConstructFeedItemMissingField()
        {
            // title removed
            XElement rssEntryItem = new XElement("entry",
                new XElement("author", new XElement("name", ""), new XElement("uri", "")),
                new XElement("category", new XAttribute("term", ""), new XAttribute("label", "")),
                new XElement("content", new XAttribute("type", ""), ""),
                new XElement("id", "1"),
                new XElement("link", new XAttribute("href", "")),
                new XElement("updated", ""),
                new XElement("published", "")
);
            FeedItem feedItem = new FeedItem("", "", "", "", "", "");

            bool feedItemEquality = fc.ConstructFeedItem(rssEntryItem).Equals(feedItem);

            Assert.That(feedItemEquality, Is.EqualTo(true));
        }



        // RedditRSS.Models.FeedConstruction.DefaultFeedConstructor.IsValidRedditRSS
        [Test]
        public void IsValidRedditRSSEmptyStringInput()
        {
            Assert.That(fc.IsValidRedditRSS(""), Is.EqualTo(false));
        }

        [Test]
        public void IsValidRedditRSSNullInput()
        {
            Assert.That(fc.IsValidRedditRSS(null), Is.EqualTo(false));
        }

        [Test]
        public void IsValidRedditRSSNonRedditLink()
        {
            Assert.That(fc.IsValidRedditRSS("www.google.com"), Is.EqualTo(false));

        }

        [Test]
        public void IsValidRedditRSSRedditLinkNotRSS()
        {
            Assert.That(fc.IsValidRedditRSS("www.reddit.com/r/all"), Is.EqualTo(false));
        }


        [Test]
        public void IsValidRedditRSSRedditLinkRSS()
        {
            Assert.That(fc.IsValidRedditRSS("https://www.reddit.com/r/all/.rss"), Is.EqualTo(true));
        }

        [Test]
        public void IsValidRedditRSSRedditLinkRSSNoSlash()
        {
            Assert.That(fc.IsValidRedditRSS("https://www.reddit.com/r/all.rss"), Is.EqualTo(true));
        }

        [Test]
        public void IsValidRedditRSSRedditLinkRSSExtraSymbolsAfter()
        {
            Assert.That(fc.IsValidRedditRSS("https://www.reddit.com/r/all/.rssQQQ"), Is.EqualTo(false));
        }

        [Test]
        public void IsValidRedditRSSRedditLinkRSSExtraSymbolsBefore()
        {
            Assert.That(fc.IsValidRedditRSS("QQQhttps://www.reddit.com/r/all/.rss"), Is.EqualTo(false));
        }

        [Test]
        public void IsValidRedditRSSRedditLinkRSSExtraSymbolsmMixed()
        {
            Assert.That(fc.IsValidRedditRSS("httpsQ:Q//wwwQ.reddit.Qcom/r/QallQ/.rssQ"), Is.EqualTo(false));
        }

    }
}