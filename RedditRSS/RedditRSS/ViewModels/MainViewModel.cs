using RedditRSS.Models;
using System.ComponentModel;

namespace RedditRSS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _userRssInput;
        private Feed _feed;

        public MainViewModel()
        {
            // Start up with an empty feed
            _userRssInput = "";
            _feed = FeedReader.ConstructFeed("");

        }

        public string UserRSSInput
        {
            get { return _userRssInput; }
            set { _userRssInput = value; }
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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
