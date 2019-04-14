using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Voting.Web.Data.Entities;

namespace Voting.Web.Models
{
    public class VotingEventViewModel : VotingEvent
    {
        [Display(Name = "Total Votes")]
        public int TotalVotes { get; set; }
    }
}
