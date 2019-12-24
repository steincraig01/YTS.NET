using Newtonsoft.Json;

namespace YTS.Models
{

    public class MovieActor
    {

        private string pImage;
        private string pIMDB;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("character_name")]
        public string Character;

        [JsonProperty("url_small_image")]
        public string Image
        {
            get { return pImage; }
            set { pImage = value.Replace("\\", string.Empty); }
        }

        [JsonProperty("imdb_code")]
        public string IMDB
        {
            get { return pIMDB; }
            set { pIMDB = "https://www.imdb.com/name/" + value; }
        }

    }

}