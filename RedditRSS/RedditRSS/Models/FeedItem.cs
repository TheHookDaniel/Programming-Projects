using System;

namespace RedditRSS.Models
{
    public class FeedItem
    {
        private readonly string _title;
        private readonly string _authorName;
        private readonly string _category;
        private readonly string _content;
        private readonly string _postUrl;
        private readonly string _id;
        private readonly DateTime _updated;
        private readonly DateTime _published;

        public FeedItem(string title, string authorName, string category, string content, string postUrl, string id)
        {
            _title = title;
            _authorName = authorName;
            _category = category;
            _content = content;
            _postUrl = postUrl;
            _id = id;
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

        public string ID
        {
            get { return _id; }
        }

        public DateTime Updated
        {
            get { return _updated; }
        }

        public DateTime Published
        {
            get { return _published; }
        }

        public override bool Equals(object? obj)
        {
            // each reddit post has its own unique ID, so comparing to that is fine
            FeedItem other = obj as FeedItem;

            if (other is null)
            {
                return false;
            }

            return this.ID == other.ID;
        }
    }
}
