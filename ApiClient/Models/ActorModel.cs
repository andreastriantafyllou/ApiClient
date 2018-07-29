using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient.Models
{
    class ActorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
    }
}
