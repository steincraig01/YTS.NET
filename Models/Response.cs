using Newtonsoft.Json;

namespace YTS.Models
{

    public class Response<Object>
    {

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("status_message")]
        public string Message;

        [JsonProperty("data")]
        public Object Data;

        [JsonProperty("@meta")]
        public Metadata Meta;

    }

}