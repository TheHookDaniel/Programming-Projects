# Reddit RSS Reader

A C# desktop application made for reading Reddit RSS feeds . 

Built with WPF in Visual Studio and tested with NUnit.

This application was made for learning purposes 

# How To Use 

## 1. Find the RSS feed for the subreddit (or multireddit) of your choice

Usually Reddit RSS feeds are made by simply adding ".rss" at the end of the URL to an existing subreddit 

`https://www.reddit.com/r/<subreddit>/.rss` 

This application also supports multireddit feeds

`https://www.reddit.com/r/<subreddit1> + <subreddit2> + ... <subredditN>/.rss` 

More info about Reddit RSS can be found [here](https://www.reddit.com/wiki/rss).

## 2. Load the feed

Load the feed after typing it's URL into the textbox. It is also possible to add an RSS feed to your favourites which enables you to pick it from the dropdown menu later on. 

![screen grab of loading](/Images/loadRSS.png)

## 3. Browse posts in the feed and view their contents

![screen grab of entire application](/Images/fullscreenGrab.png)