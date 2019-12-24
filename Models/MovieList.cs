using Newtonsoft.Json;

namespace YTS.Models
{

    public class MovieList
    {

        [JsonProperty("movie_count")]
        public int Count;

        [JsonProperty("limit")]
        public int Limit;

        [JsonProperty("page_number")]
        public int Page;

        [JsonProperty("movies")]
        public MovieInfo[] Movies;

    }

}