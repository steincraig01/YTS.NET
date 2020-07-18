using Newtonsoft.Json;
using System;

namespace YTS.Models
{
    public class MovieInfo
    {
        private string pURL;
        private string pIMDB;
        private string pTrailer;
        private string pBackground;
        private string pBackgroundOriginal;
        private string pSmallCover;
        private string pMediumCover;
        private string pLargeCover;

        [JsonProperty("id")]
        public int ID;

        [JsonProperty("url")]
        public string URL
        {
            get => pURL;
            set => pURL = value.Replace("\\", string.Empty);
        }

        [JsonProperty("imdb_code")]
        public string IMDB
        {
            get => pIMDB;
            set => pIMDB = "https://www.imdb.com/title/" + value;
        }

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("title_english")]
        public string TitleEnglish;

        [JsonProperty("title_long")]
        public string TitleLong;

        [JsonProperty("slug")]
        public string TitleSlug;

        [JsonProperty("year")]
        public int Year;

        [JsonProperty("rating")]
        public float Rating;

        [JsonProperty("runtime")]
        public int Duration;

        [JsonProperty("genres")]
        public string[] Genres;

        [JsonProperty("summary")]
        public string Summary;

        [JsonProperty("description_full")]
        public string Description;

        [JsonProperty("synopsis")]
        public string Synopsis;

        [JsonProperty("yt_trailer_code")]
        public string Trailer
        {
            get => pTrailer;
            set => pTrailer = "https://www.youtube.com/watch?v=" + value;
        }

        [JsonProperty("language")]
        public string Language;

        [JsonProperty("mpa_rating")]
        public string MPA;

        [JsonProperty("background_image")]
        public string Background
        {
            get => pBackground;
            set => pBackground = value.Replace("\\", string.Empty);
        }

        [JsonProperty("background_image_original")]
        public string BackgroundOriginal
        {
            get => pBackgroundOriginal;
            set => pBackgroundOriginal = value.Replace("\\", string.Empty);
        }

        [JsonProperty("small_cover_image")]
        public string SmallCover
        {
            get => pSmallCover;
            set => pSmallCover = value.Replace("\\", string.Empty);
        }

        [JsonProperty("medium_cover_image")]
        public string MediumCover
        {
            get => pMediumCover;
            set => pMediumCover = value.Replace("\\", string.Empty);
        }

        [JsonProperty("large_cover_image")]
        public string LargeCover
        {
            get => pLargeCover;
            set => pLargeCover = value.Replace("\\", string.Empty);
        }

        [JsonProperty("state")]
        public string State;

        [JsonProperty("torrents")]
        public MovieTorrent[] Torrents;

        [JsonProperty("date_uploaded")]
        public DateTime DateUploaded;

        [JsonProperty("date_uploaded_unix")]
        public uint DateUploadedUnix;
    }
}