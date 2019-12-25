using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YTS.Models;

namespace YTS
{

    public class Services
    {

        private string API;
        private string Key;

        private WebClient Client = new WebClient();
        private HttpClient ClientAsync = new HttpClient();

        public Services(string API, string Key = null)
        {
            this.API = new Uri(API).AbsoluteUri;
            this.Key = Key;
        }

        public Services(Uri API, string Key = null)
        {
            this.API = API.AbsoluteUri;
            this.Key = Key;
        }

        public Response<MovieList> GetMovieList(string Query)
        {
            var Endpoint = string.Format("list_movies.json?query_term={0}", Query.Replace(" ", "+"));
            var Request = Path.Combine(API, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieList>>(Data);
        }

        public async Task<Response<MovieList>> GetMovieListAsync(string Query)
        {
            var Endpoint = string.Format("list_movies.json?query_term={0}", Query.Replace(" ", "+"));
            var Request = Path.Combine(API, Endpoint);
            var Data = await ClientAsync.GetStringAsync(Request);
            return JsonConvert.DeserializeObject<Response<MovieList>>(Data);
        }

        public Response<MovieDetailsWrap> GetMovieDetails(int ID)
        {
            var Endpoint = string.Format("movie_details.json?movie_id={0}&with_images=true&with_cast=true", ID);
            var Request = Path.Combine(API, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieDetailsWrap>>(Data);
        }

        public async Task<Response<MovieDetailsWrap>> GetMovieDetailsAsync(int ID)
        {
            var Endpoint = string.Format("movie_details.json?movie_id={0}&with_images=true&with_cast=true", ID);
            var Request = Path.Combine(API, Endpoint);
            var Data = await ClientAsync.GetStringAsync(Request);
            return JsonConvert.DeserializeObject<Response<MovieDetailsWrap>>(Data);
        }

        public Response<MovieSuggestions> GetMovieSuggestions(int ID)
        {
            var Endpoint = string.Format("movie_suggestions.json?movie_id={0}", ID);
            var Request = Path.Combine(API, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieSuggestions>>(Data);
        }

        public async Task<Response<MovieSuggestions>> GetMovieSuggestionsAsync(int ID)
        {
            var Endpoint = string.Format("movie_suggestions.json?movie_id={0}", ID);
            var Request = Path.Combine(API, Endpoint);
            var Data = await ClientAsync.GetStringAsync(Request);
            return JsonConvert.DeserializeObject<Response<MovieSuggestions>>(Data);
        }

    }

}