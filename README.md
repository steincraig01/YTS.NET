# YTS.NET

A Lightweight .NET Wrapper For YTS API.

This is my first ever project that is published online, I may make a couple of mistakes so let me know how to improve it.

## Getting Started

You will need a version that is [compatible with .NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard).

Firstly, you will need to install the library from [NuGet](https://www.nuget.org/packages/YTS.NET) or just directly from the [releases](https://github.com/virgincode/YTS.NET/releases). Those who are downloading directly from releases should mind about the dependencies.

```
Install-Package YTS.NET
```

Secondly, create a API Service from the library.

```
var Service = new YTS.API(new Uri("https://yts.lt/api/v2"));
```

Finally, you can use all of the power from YTS.

#### Full Usage

Right here in this code, I'm searching for a movie with the query "harry potter" and selecting the first movie, and then getting a 720p quality torrent magnet link.

```
var Service = new YTS.API(new Uri("https://yts.lt/api/v2")); 
var Response = Service.GetMovieList("harry potter"); // Search Movies Matching Query
var Movie = Response.Data.Movies[0]; // Selecting First Movie
string Magnet = null;
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
foreach (var Torrent in Movie.Torrents)
	if (Torrent.Quality == "720p") // Search Torrent With 720p Quality
		Magnet = Torrent.GetMagnet("Harry Potter 720p Movie", Trackers);
System.Diagnostics.Process.Start(Magnet); // Starts Another Program To Download Movie Or You Can Make Your Own.
```