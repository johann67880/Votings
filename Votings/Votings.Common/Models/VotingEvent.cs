using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Votings.Common.Models
{
    public class VotingEvent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("candidates")]
        public List<Candidate> Candidates { get; set; } = new List<Candidate>();

        [JsonProperty("votes")]
        public List<Vote> Votes { get; set; } = new List<Vote>();

        [JsonProperty("totalCandidates")]
        public int TotalCandidates { get { return this.Candidates == null ? 0 : this.Candidates.Count(); } }

        [JsonProperty("totalVotes")]
        public int TotalVotes { get { return this.Votes == null ? 0 : this.Votes.Count(); } }
    }
}
