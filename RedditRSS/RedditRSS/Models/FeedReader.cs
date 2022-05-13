using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RedditRSS.Models
{
    public class FeedReader
    {
        public static Feed ConstructFeed(string rssSource)
        {
            if (string.IsNullOrEmpty(rssSource) || !IsValidRedditRSS(rssSource))
            {
                // return empty feed if no rss source has been passed
                return new Feed("", "", "");
            }

            XElement xmlRoot = XElement.Load(rssSource);
            XNamespace xmlNamespace = "http://www.w3.org/2005/Atom";

            if (xmlRoot is null)
            {
                throw new ArgumentException("Invalid RSS source");
            }

            XElement? rssTitle = xmlRoot.Element(xmlNamespace + "title");
            XElement? rssSubTitle = xmlRoot.Element(xmlNamespace + "subtitle");

            if (rssTitle is null)
            {
                throw new ArgumentException("title not found");
            }

            if (rssSubTitle is null)
            {
                throw new ArgumentException("subtitle not found");

            }

            Feed rssFeed = new Feed(rssTitle.Value, rssSubTitle.Value, rssSource);

            IEnumerable<XElement> xmlEntryElements = xmlRoot.Elements(xmlNamespace + "entry");

            foreach (XElement xmlItem in xmlEntryElements)
            {
                rssFeed.Add(ConstructFeedItem(xmlItem, xmlNamespace));
            }

            return rssFeed;
        }

        public static FeedItem ConstructFeedItem(XElement xmlItem, XNamespace xmlNamespace)
        {
            if (xmlItem is null || xmlItem.Name.LocalName != "entry")
            {
                return new FeedItem("", "", "", "", "");
            }

            string title = xmlItem.Element(xmlNamespace + "title").Value;
            string authorName = xmlItem.Element(xmlNamespace + "author").Element(xmlNamespace + "name").Value;
            string category = xmlItem.Element(xmlNamespace + "category").Attribute("label").Value;
            string content = xmlItem.Element(xmlNamespace + "content").Value;
            string postUrl = xmlItem.Element(xmlNamespace + "link").Attribute("href").Value;
            
            return new FeedItem(title, authorName, category, content, postUrl);
        }

        public static bool IsValidRedditRSS(string rssSource)
        {
            return true;
        }
    }
}
