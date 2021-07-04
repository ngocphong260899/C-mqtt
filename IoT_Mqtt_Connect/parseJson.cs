using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace IoT_Mqtt_Connect
{
    class parseJson
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("sw_wifi")]
        public string sw_wifi { get; set; }

        [JsonProperty("pos")]
        public string pos { get; set; }

        [JsonProperty("control")]
        public string control { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("ssid")]
        public string ssid { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("streng")]
        public string streng { get; set; }







    }
}
