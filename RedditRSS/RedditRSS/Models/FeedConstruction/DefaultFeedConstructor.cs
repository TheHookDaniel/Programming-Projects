using System;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace RedditRSS.Models.FeedConstruction
{
    /*
     * In the following implementation the returned XML is assumed to have structure 
     * like the one found in RedditRSS_Example.xml. If the structure changes,
     * it is possible to accomodate for this by implementing a new IFeedConstructor.
     */

    public class DefaultFeedConstructor : IFeedConstructor
    {
        public Feed ConstructFeed(string rssSource)
        {
            if (!IsValidRedditRSS(rssSource))
            {
                // return empty feed if no rss source has been passed
                return new Feed("", "", "");
            }

            XElement xmlRoot;
            try
            {
                xmlRoot = XElement.Load(rssSource);
            }
            catch (Exception)
            {
                return new Feed("", "", "");
            }

            XNamespace xmlNamespace = xmlRoot.Name.Namespace;
            XElement? rssTitle = xmlRoot.Element(xmlNamespace + "title");
            XElement? rssSubTitle = xmlRoot.Element(xmlNamespace + "subtitle");

            Feed rssFeed;
            try
            {
                rssFeed = new Feed(rssTitle.Value, rssSubTitle.Value, rssSource);
            }
            catch (NullReferenceException)
            {
                // some subreddits don't have a 'subtitle' and a multi-subreddit doesn't have a subtitle
                rssFeed = new Feed(rssTitle.Value, "", rssSource);
            }

            IEnumerable<XElement> xmlEntryElements = xmlRoot.Elements(xmlNamespace + "entry");

            foreach (XElement xmlItem in xmlEntryElements)
            {
                rssFeed.Add(ConstructFeedItem(xmlItem));
            }

            return rssFeed;
        }

        public FeedItem ConstructFeedItem(XElement xmlItem)
        {
            if (xmlItem is null || xmlItem.Name.LocalName != "entry")
            {
                return new FeedItem("", "", "", "", "", "");
            }

            XNamespace xmlNamespace = xmlItem.Name.Namespace;

            XElement? title = xmlItem.Element(xmlNamespace + "title");
            XElement? authorName = xmlItem.Element(xmlNamespace + "author")?.Element(xmlNamespace + "name");
            XAttribute? category = xmlItem.Element(xmlNamespace + "category")?.Attribute("label");
            XElement? content = xmlItem.Element(xmlNamespace + "content");
            XAttribute? postUrl = xmlItem.Element(xmlNamespace + "link")?.Attribute("href");
            XElement? postID = xmlItem.Element(xmlNamespace + "id");

            // assume that any missing field is caused by a faulty argument, thus invalidating all the other fields
            if (title is null || authorName is null || category is null || content is null || postUrl is null)
            {
                return new FeedItem("", "", "", "", "", "");
            }

            return new FeedItem(title.Value, authorName.Value, category.Value, content.Value, postUrl.Value, postID.Value);
        }

        public bool IsValidRedditRSS(string rssSource)
        {
            // assume link is invalid until proven otherwise
            bool isValidURL = false;

            if (rssSource is not null)
            {
                string rxPattern = @"^https:\/\/www\.reddit\.com\/r\/(?<subreddit>[a-zA-Z]+)\/?\.rss$";
                Regex rx = new Regex(rxPattern);
                MatchCollection matches = rx.Matches(rssSource);

                if (matches.Count == 1)
                {
                    isValidURL = true;
                }
            }

            return isValidURL;
        }
    }
}
