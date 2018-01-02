﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BasicTrelloImplementation.CardJsonTypes;

namespace BasicTrelloImplementation.CardJsonTypes
{

    public class Label
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("idBoard")]
        public string IdBoard { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("uses")]
        public int Uses { get; set; }
    }

}