using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RedditRSS.Models.FeedConstruction
{
    // Default behaviour is 
    public class DefaultFeedConstructor : IFeedConstructor
    {
        public Feed ConstructFeed(string rssSource)
        {
            return new Feed("", "", "");
        }

        public FeedItem ConstructFeedItem(XElement xmlItem)
        {
            return new FeedItem("", "", "", "", "");
        }

        public bool IsValidRedditRSS(string rssSource)
        {
            return false;
        }
    }
}
