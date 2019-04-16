using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Common.Models
{
    public class Vote
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("votingEvent")]
        public VotingEvent VotingEvent { get; set; }

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("registrationDate")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
