# YTS.NET

[![nuget](https://img.shields.io/nuget/v/YTS.NET)](https://nuget.org/packages/YTS.NET)

YTS.NET is a .NET Wrapper for YTS API. It provides access to __working functionalities__ of the API like listing movies and so on. As of right now writing this document, there is only three working functions in the API, not the library, the [API documentary](https://yts.lt/api/v2) of YTS might be outdated or incomplete. And fun fact, this is my first ever project that is published online!

## Getting Started

First of all you must have a targetting version that is compatible with .NET Standard 2.0, once you have the right version you install YTS.NET from the [Package Manager Console](https://docs.nuget.org/consume/package-manager-console) or using the [Package Manager Dialog](https://docs.nuget.org/consume/Package-Manager-Dialog).

**Package Manager Console**

1. In Visual Studio, Click `View` > `Other Windows` > `Package Manager Console`.

2. Type in, `Install-Package YTS.NET` to get the latest version.

**Package Manager Dialog**

1. Right-click on your project and select `Manage NuGet Packages`.

2. Search for `YTS.NET` and click `Install` to get the latest version.

### API Usage

Let's say we are searching for a movie, let's say "harry potter" and so I put it in the method and get the response, and then select the movie that comes first in the results

```
var API = new YTS.Services(new Uri("https://yts.lt/api/v2"));
var Response = API.GetMovieList("harry potter"); // Searches For Movies With The Query
var Movies = Response.Data.Movies; // Results Matching The Query
var Movie = Movies[0]; // Selecting The First Movie
```

And then let's get the movie's cast and then get other movie suggestions for the user.

```
var Details = API.GetMovieDetails(Movie.ID); // Gets Movie Details
var Cast = Details.Data.Movie.Cast; // Array Containing Actors
var Suggestions = API.GetMovieSuggestions(Movie.ID).Data.Movies; // Array Containing Movie Suggestions
```

And so, we'll get a 1080p torrent magnet link for that movie, and trackers for the torrent.

```
var Trackers = new string[] // Creating Trackers For Torrent
{
	"udp://open.demonii.com:1337/announce",
	"udp://tracker.openbittorrent.com:80",
	"udp://tracker.coppersurfer.tk:6969",
	"udp://glotorrents.pw:6969/announce",
	"udp://tracker.opentrackr.org:1337/announce",
	"udp://torrent.gresille.org:80/announce",
	"udp://p4p.arenabg.com:1337",
	"udp://tracker.leechers-paradise.org:6969"
};
string Magnet = null;
foreach (var Torrent in Movie.Torrents)
    if (Torrent.Quality == "1080p") // Checks If The Torrent Is 1080p
        Magnet = Torrent.GetMagnet("NAME THE TORRENT ANYTHING YOU WANT", Trackers); // Gets The Magnet Link
System.Diagnostics.Process.Start(Magnet); // Calls Another Program To Download The Movie
```

And that's all I can explain for now. Anything wrong with the documentary or the project, please add an issue.
