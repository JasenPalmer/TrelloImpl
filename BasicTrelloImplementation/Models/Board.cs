﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace BasicTrelloImplementation.Models
{

    public class Board
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("descData")]
        public string DescData { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

    }

}
