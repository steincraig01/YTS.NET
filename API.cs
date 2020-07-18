using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YTS.Models;

namespace YTS
{
    [Obsolete("This Class Is Replaced By Another Class, Please Use YTS.Services!")]
    public class API
    {
        private readonly string URL;
        private readonly WebClient Client = new WebClient();

        public API(string URL) => this.URL = new Uri(URL).AbsoluteUri;

        public API(Uri URL) => this.URL = URL.AbsoluteUri;

        public Response<MovieList> GetMovieList(string Query)
        {
            var Endpoint = string.Format("list_movies.json?query_term={0}", Query.Replace(" ", "+"));
            var Request = Path.Combine(URL, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieList>>(Data);
        }

        public Response<MovieDetailsWrap> GetMovieDetails(int ID)
        {
            var Endpoint = string.Format("movie_details.json?movie_id={0}&with_images=true&with_cast=true", ID);
            var Request = Path.Combine(URL, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieDetailsWrap>>(Data);
        }

        public Response<MovieSuggestions> GetMovieSuggestions(int ID)
        {
            var Endpoint = string.Format("movie_suggestions.json?movie_id={0}", ID);
            var Request = Path.Combine(URL, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieSuggestions>>(Data);
        }
    }
}