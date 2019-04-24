using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Vote> Votes { get; set; }

        public int TotalVotes { get { return this.Votes == null ? 0 : this.Votes.Count(); } }
    }
}
