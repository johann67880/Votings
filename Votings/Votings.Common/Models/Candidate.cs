using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Common.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Proposal")]
        public string Proposal { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        public string ImageFullPath { get; set; }
    }
}
