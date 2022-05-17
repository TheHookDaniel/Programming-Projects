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
        bool IsValidRedditRSS(string rssSource);
    } 
}
