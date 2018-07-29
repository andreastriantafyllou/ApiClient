using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient.Models
{
    public class MovieModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("year")]
        public int ProductionYear { get; set; }
        [JsonProperty("actors")]
        public List<int> ActorIds { get; set; }
        [JsonProperty("director")]
        public int DirectorIds { get; set; }
    }
}
