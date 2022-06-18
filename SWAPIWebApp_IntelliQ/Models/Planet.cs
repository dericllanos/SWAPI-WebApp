using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPIWebApp_IntelliQ.Models
{
    public class Planet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }

        [JsonProperty("residents")]
        public List<string> Residents { get; set; }

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
