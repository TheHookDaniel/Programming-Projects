using System.ComponentModel;
using RedditRSS.Commands;
using RedditRSS.Models;
using RedditRSS.Models.FeedConstruction;

namespace RedditRSS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public LoadRSSCommand LoadRSSCommand { get; private set; }

        private Feed _feed;
        private IFeedConstructor _feedConstructor;

        public MainViewModel()
        {
            // Start with an empty feed
            _feedConstructor = new DefaultFeedConstructor();
            _feed = _feedConstructor.ConstructFeed("");
            LoadRSSCommand = new LoadRSSCommand(UpdateFeed);
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
            Feed returnFeed = _feedConstructor.ConstructFeed(rssSource);
            if (!returnFeed.Equals(new Feed("", "", "")))
            {
                Feed = _feedConstructor.ConstructFeed(rssSource);
            }
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
