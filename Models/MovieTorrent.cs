using Newtonsoft.Json;
using System;

namespace YTS.Models
{
    public class MovieTorrent
    {
        private string pURL;

        [JsonProperty("url")]
        public string URL
        {
            get => pURL;
            set => pURL = value.Replace("\\", string.Empty);
        }

        [JsonProperty("hash")]
        public string Hash;

        [JsonProperty("quality")]
        public string Quality;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("seeds")]
        public int Seeds;

        [JsonProperty("peers")]
        public int Peers;

        [JsonProperty("size")]
        public string Size;

        //[JsonProperty("size_bytes")]
        //public int SizeBytes;

        [JsonProperty("date_uploaded")]
        public DateTime DateUploaded;

        //[JsonProperty("date_uploaded_unix")]
        //public int DateUploadedUnix;

        public string CreateMagnet(string Name, string[] Trackers)
        {
            string BTIH = Hash;
            string DN = Name.Replace(" ", "+");
            string TR = null;
            foreach (var Tracker in Trackers)
                TR += "&tr=" + Tracker;
            return string.Format("magnet:?xt=urn:btih:{0}&dn={1}{2}", BTIH, DN, TR);
        }
    }
}