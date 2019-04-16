using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Common.Models
{
    public class Candidate
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("proposal")]
        public string Proposal { get; set; }

        [JsonProperty("imageFullPath")]
        public string ImageFullPath { get; set; }

        public byte[] ImageArray { get; set; }
    }
}
