using System;

namespace RedditRSS.Models
{
    public class FeedItem
    {
        private string _title;
        private string _authorName;
        private string _category;
        private string _content;
        private string _postUrl;
        private DateTime _updated;
        private DateTime _published;

        public FeedItem(string title, string authorName, string category, string content, string postUrl)
        {
            _title = title;
            _authorName = authorName;
            _category = category;
            _content = content;
            _postUrl = postUrl;
            _updated = DateTime.Now;
            _published = DateTime.Now;
        }

        public string Title
        {
            get { return _title; }
        }

        public string AuthorName
        {
            get { return _authorName; }
        }

        public string Category
        {
            get { return _category; }
        }

        public string Content
        {
            get { return _content; }
        }

        public string PostUrl
        {
            get { return _postUrl; }
        }

        public DateTime Updated
        {
            get { return _updated; }
        }

        public DateTime Published
        {
            get { return _published; }
        }
    }
}
