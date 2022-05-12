using System.Linq;
using System.Xml.Linq;

namespace RedditRSS.Models
{
    public class FeedReader
    {
        public static Feed Read(string rssSource)
        {
            if (string.IsNullOrEmpty(rssSource))
            {
                // return empty feed if no rss source has been passed
                return new Feed("", "", "");
            }

            XElement rssRoot = XElement.Load(rssSource);

            var rssItems = 
                from rssItem in rssRoot.Elements()
                where rssItem.Name == "entry"
                select rssItem;

            Feed rssFeed = new Feed("", "", "");

            return rssFeed;

        }

    }
}
