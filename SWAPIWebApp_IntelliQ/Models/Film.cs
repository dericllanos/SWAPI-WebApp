using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPIWebApp_IntelliQ.Models
{
    public class Film
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("characters")]
        public List<string> Characters { get; set; }

        [JsonProperty("planets")]
        public List<string> Planets { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
