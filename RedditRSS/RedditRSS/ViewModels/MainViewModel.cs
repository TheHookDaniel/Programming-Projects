using System.Collections.ObjectModel;
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
        public AddFavouriteRSSCommand AddFavouriteRSSCommand { get; private set; }

        private ObservableCollection<string> _favourites;
        private Feed _feed;
        private IFeedConstructor _feedConstructor;

        public MainViewModel()
        {
            // Start with an empty feed
            _feedConstructor = new DefaultFeedConstructor();
            _feed = _feedConstructor.ConstructFeed("");
            _favourites = new ObservableCollection<string>() { };
            LoadRSSCommand = new LoadRSSCommand(UpdateFeed);
            AddFavouriteRSSCommand = new AddFavouriteRSSCommand(UpdateFavourites);
        }

        public ObservableCollection<string> Favourites
        {
            get
            {
                return _favourites;
            }
            set
            {
                _favourites = value;
                this.OnPropertyChanged("Favourites");

            }
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

        public void UpdateFavourites(string rssFeedUrl)
        {
            if (_feedConstructor.IsValidRedditRSS(rssFeedUrl))
            {
                _favourites.Add(rssFeedUrl);
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
