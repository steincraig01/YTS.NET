using Newtonsoft.Json;

namespace YTS.Models
{

    public class Metadata
    {

        [JsonProperty("server_time")]
        public uint Time;

        [JsonProperty("server_timezone")]
        public string Timezone;

        [JsonProperty("api_version")]
        public int Version;

        [JsonProperty("execution_time")]
        public string Delay;

    }

}