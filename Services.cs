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
        private readonly string API;
        private string Key;

        private readonly WebClient Client = new WebClient();
        private readonly HttpClient ClientAsync = new HttpClient();

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

        public Response<MovieList> GetMovieList(int Limit = 20, int Page = 1, string MovieQuality = MovieQuality.All, int MinimumRating = 0, string Query = "", string Genre = "All", string SortBy = SortBy.DateAdded, string OrderBy = OrderBy.Decending)
        {
            var Endpoint = string.Format("list_movies.json?limit={0}&page={1}&quality={2}&minimum_rating={3}&query_term={4}&genre={5}&sorty_by={6}&order_by={7}"
                , Limit, Page, MovieQuality, MinimumRating, Query.Replace(" ", "+"), Genre, SortBy, OrderBy);
            var Request = Path.Combine(API, Endpoint);
            var Data = Client.DownloadString(Request);
            return JsonConvert.DeserializeObject<Response<MovieList>>(Data);
        }

        public async Task<Response<MovieList>> GetMovieListAsync(int Limit = 20, int Page = 1, string MovieQuality = MovieQuality.All, int MinimumRating = 0, string Query = "", string Genre = "All", string SortBy = SortBy.DateAdded, string OrderBy = OrderBy.Decending)
        {
            var Endpoint = string.Format("list_movies.json?limit={0}&page={1}&quality={2}&minimum_rating={3}&query_term={4}&genre={5}&sorty_by={6}&order_by={7}"
                , Limit, Page, MovieQuality, MinimumRating, Query.Replace(" ", "+"), Genre, SortBy, OrderBy);
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