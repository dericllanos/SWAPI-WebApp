using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPIWebApp_IntelliQ.Models
{
    public class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("average_height")]
        public string AverageHeight { get; set; }

        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; }

        [JsonProperty("hair_colors")]
        public string HairColors { get; set; }

        [JsonProperty("eye_colors")]
        public string EyeColors { get; set; }

        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; }

        [JsonProperty("homeworld")]
        public object Homeworld { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("people")]
        public List<string> People { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
