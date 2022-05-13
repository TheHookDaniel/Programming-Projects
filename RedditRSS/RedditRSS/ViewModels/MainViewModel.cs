using RedditRSS.Commands;
using RedditRSS.Models;
using System.ComponentModel;

namespace RedditRSS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public LoadRSSCommand LoadRSSCommand { get; private set; }

        private Feed _feed;

        public MainViewModel()
        {
            // Start with an empty feed
            _feed = FeedReader.ConstructFeed("");
            LoadRSSCommand = new LoadRSSCommand(UpdateFeed, FeedReader.IsValidRedditRSS);
        }

        public Feed Feed
        {
            get 
            { 
                return _feed;
            }
            set 
            { 
                _feed = value;
                this.OnPropertyChanged("Feed");
            }
        }

        public void UpdateFeed(string rssSource)
        {
            Feed = FeedReader.ConstructFeed(rssSource);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
