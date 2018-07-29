using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient.Models
{
    public class MoviesDBScheme
    {
        [JsonProperty("actors")]
        public string ActorsPath { get; set; }
        [JsonProperty("directors")]
        public string DirectorsPath { get; set; }
        [JsonProperty("movies")]
        public string MoviesPath { get; set; }
    }
}
