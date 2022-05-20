using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RedditRSS.Models
{
    public interface IFeedConstructor
    {   
        Feed ConstructFeed(string rssSource);
        FeedItem ConstructFeedItem(XElement xmlItem);
        // Validating the structure of the provided RSS url is correct, not if the subreddit actually exists
        bool IsValidRedditRSS(string rssSource);
    } 
}
