using Newtonsoft.Json;

namespace YTS.Models
{

    public class MovieDetailsWrap
    {

        [JsonProperty("movie")]
        public MovieDetails Movie;

    }

}