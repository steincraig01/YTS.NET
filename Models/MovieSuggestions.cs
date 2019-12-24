using Newtonsoft.Json;

namespace YTS.Models
{

    public class MovieSuggestions
    {

        [JsonProperty("movie_count")]
        public int Count;

        [JsonProperty("movies")]
        public MovieInfo[] Suggestions;

    }

}