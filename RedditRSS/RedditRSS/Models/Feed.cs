using System.Collections.ObjectModel;

namespace RedditRSS.Models
{
    public class Feed : ObservableCollection<FeedItem>
    {
        private string _title;
        private string _subtitle;
        private string _feedUrl;
        
        public Feed(string title, string subtitle, string feedUrl) : base()
        {
            _title = title;
            _subtitle = subtitle;
            _feedUrl = feedUrl;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }

        public string FeedUrl
        {
            get { return _feedUrl; }
            set { _feedUrl = value; }
        }
    }
}