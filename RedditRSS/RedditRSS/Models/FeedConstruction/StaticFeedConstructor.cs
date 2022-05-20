using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RedditRSS.Models
{
    public class StaticFeedConstructor
    {
        public static Feed ConstructFeed(string rssSource)
        {
            if (!IsValidRedditRSS(rssSource))
            {
                // return empty feed if no rss source has been passed
                return new Feed("", "", "");
            }

            XElement xmlRoot = XElement.Load(rssSource);
            XNamespace xmlNamespace = xmlRoot.Name.Namespace;

            if (xmlRoot is null)
            {
                throw new ArgumentException("Faulty RSS source");
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
                rssFeed.Add(ConstructFeedItem(xmlItem));
            }

            return rssFeed;
        }

        public static FeedItem ConstructFeedItem(XElement xmlItem)
        {
            if (xmlItem is null || xmlItem.Name.LocalName != "entry")
            {
                return new FeedItem("", "", "", "", "", "");
            }

            XNamespace xmlNamespace  = xmlItem.Name.Namespace;

            XElement? title = xmlItem.Element(xmlNamespace + "title");
            XElement? authorName = xmlItem.Element(xmlNamespace + "author")?.Element(xmlNamespace + "name");
            XAttribute? category = xmlItem.Element(xmlNamespace + "category")?.Attribute("label");
            XElement? content = xmlItem.Element(xmlNamespace + "content");
            XAttribute? postUrl = xmlItem.Element(xmlNamespace + "link")?.Attribute("href");
            XElement? postID = xmlItem.Element(xmlNamespace + "id");

            // assume that any missing field is caused by a faulty argument, thus invalidating all the other fields
            if(title is null || authorName is null || category is null || content is null || postUrl is null)
            {
                return new FeedItem("", "", "", "", "", "");
            }
            
            return new FeedItem(title.Value, authorName.Value, category.Value, content.Value, postUrl.Value, postID.Value);
        }

        public static bool IsValidRedditRSS(string rssSource)
        {
            return !string.IsNullOrEmpty(rssSource);
        }
    }
}
