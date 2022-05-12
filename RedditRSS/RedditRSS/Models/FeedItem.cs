using System;

namespace RedditRSS.Models
{
    public class FeedItem
    {
        private string _title;
        private string _authorName;
        private string _authorProfile;
        private string _category;
        private string _content;
        private string _id;
        private string _media;
        private string _postUrl;
        private DateTime _updated;
        private DateTime _published;

        public FeedItem(string title, string authorName, string authorProfile, string category, string content, string id, string postUrl, DateTime updated, DateTime published, string media = "")
        {
            _title = title;
            _authorName = authorName;
            _authorProfile = authorProfile;
            _category = category;
            _content = content;
            _id = id;
            _media = media;
            _postUrl = postUrl;
            _updated = updated;
            _published = published;
        }

        public string Title
        {
            get { return _title; }
        }

        public string AuthorName
        {
            get { return _authorName; }
        }

        public string AuthorProfile
        {
            get { return _authorProfile; }
        }

        public string Category
        {
            get { return _category; }
        }

        public string Content
        {
            get { return _content; }
        }

        public string ID
        {
            get { return _id; }
        }

        public string ThumbNail
        {
            get { return _media; }
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
